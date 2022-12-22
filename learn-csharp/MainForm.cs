using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace learn_csharp
{
    public partial class MainForm : Form
    {
        private const string ws_uri = "wss://pipeline.vrchat.cloud/";
        private const string invite_uri = "https://api.vrchat.cloud/api/1/invite/";

        private HttpClient client = new HttpClient();
        private ClientWebSocket? _ws = new ClientWebSocket();
        private AllowUserJson _allowUserJson;

        private int guestCount = 0;

        public MainForm()
        {
            InitializeComponent();

            _allowUserJson = new AllowUserJson(this);
            _allowUserJson.loadAllowUsers();

        }

        private async Task<int> sendInvite(string userId)
        {
            var request = new HttpRequestMessage();

            request.RequestUri = new Uri($"{invite_uri}{userId}");
            request.Method = HttpMethod.Post;
            request.Headers.Add("Cookie", $"apiKey=JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26; auth={authToken.Text}");
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36");

            request.Content = new StringContent($"{{\"instanceId\": \"{targetInstanceId.Text}\", \"messageSlot\": 0}}", Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);

            return (int)response.StatusCode;
        }

        private async void webSocketHandler()
        {
            var url = $"{ws_uri}?authToken={authToken.Text}";

            if (_ws != null)
            {
                _ws.Options.SetRequestHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36");

                await _ws.ConnectAsync(new Uri(url), CancellationToken.None);
                authToken.Enabled = false;
                
                while (true)
                {
                    var buffer = new ArraySegment<byte>(new byte[65536]);

                    var result = await _ws.ReceiveAsync(buffer, CancellationToken.None);

                    if (result.Count > 0)
                    {
                        var message = Encoding.UTF8.GetString(buffer.Array, buffer.Offset, result.Count);
                        if (message != null)
                        {
                            Invoke((MethodInvoker)(() => webSocketLog.AppendText(message + Environment.NewLine)));

                            analyzeMessage(message);
                        }
                    }
                }
            }
        }

        private async void analyzeMessage(string msg)
        {
            RootJson? res = JsonSerializer.Deserialize<RootJson>(msg);
            if (res == null) return;

            if (res.type == "notification")
            {
                //通知
                NotificationContent? notify = JsonSerializer.Deserialize<NotificationContent>(res.content);
                if (notify == null) return;

                if (notify.type == "requestInvite")
                {
                    instanceManagerLog.AppendText($"Request Invite by {notify.senderUsername}\r\n");

                    if (staffOnlyMode.Checked == true)
                    {
                        //スタッフのみ許可
                        if (allowUserList.Items.Contains(notify.senderUserId))
                        {
                            if (await sendInvite(notify.senderUserId) == 200)
                            {
                                instanceManagerLog.AppendText($"Send Invite to {notify.senderUsername}\r\n");
                                inviteWaitList.Items.Add(notify.senderUserId);
                            }
                        }
                    }
                    else
                    {
                        //全ユーザー許可
                        if (guestCount < (int)maxGuestUser.Value)
                        {
                            //インスタンスに空きあり
                            if (!inviteWaitList.Items.Contains(notify.senderUserId))
                            {
                                if (await sendInvite(notify.senderUserId) == 200)
                                {
                                    guestCount++;
                                    instanceManagerLog.AppendText($"Send Invite to {notify.senderUsername}\r\n");
                                    inviteWaitList.Items.Add(notify.senderUserId);
                                }
                            }
                        }
                        else
                        {
                            //空き待ちリストに追加(重複防止)
                            if (!instaceFullWaitList.Items.Contains(notify.senderUserId))
                            {
                                instanceManagerLog.AppendText($"Add waitlist to {notify.senderUsername}\r\n");
                                instaceFullWaitList.Items.Add(notify.senderUserId);
                            }
                        }
                    }
                }

            }
            else if (res.type == "friend-location")
            {
                //場所移動
                LocationContent? location = JsonSerializer.Deserialize<LocationContent>(res.content);
                if (location == null) return;

                if (location.location == "traveling") //入場、退場ともに必ずtravelingになる
                {
                    if (location.travelingToLocation == targetInstanceId.Text)
                    {
                        //入場確定
                        instanceManagerLog.AppendText($"{location.user.displayName} is Joining\r\n");
                        inviteWaitList.Items.Remove(location.userId);
                        inWorldList.Items.Add(location.userId);
                    }
                    else if (inWorldList.Items.Contains(location.userId))
                    {
                        //退場確定
                        instanceManagerLog.AppendText($"{location.user.displayName} is Leaved by moved\r\n");
                        inWorldList.Items.Remove(location.userId);
                        guestCount--;
                        checkInstanceBrank();
                    }
                }else if(location.location == "private")
                {
                    if (inWorldList.Items.Contains(location.userId))
                    {
                        //プラベに移動した場合の退場処理
                        instanceManagerLog.AppendText($"{location.user.displayName} is Leaved by moved\r\n");
                        inWorldList.Items.Remove(location.userId);
                        guestCount--;
                        checkInstanceBrank();
                    }
                }
            }
            else if (res.type == "friend-offline")
            {
                //オフライン
                FriendOfflineContent? offlineRes = JsonSerializer.Deserialize<FriendOfflineContent>(res.content);

                if (offlineRes != null)
                {
                    if (inWorldList.Items.Contains(offlineRes.userId))
                    {
                        //クライアント断で退場
                        instanceManagerLog.AppendText($"{offlineRes.userId} is Leaved by Client killed\r\n");
                        inWorldList.Items.Remove(offlineRes.userId);
                        guestCount--;
                        checkInstanceBrank();
                    }
                    else if (inviteWaitList.Items.Contains(offlineRes.userId))
                    {
                        //インバイト待ち状態で切断
                        inviteWaitList.Items.Remove(offlineRes.userId);
                        guestCount--;
                        checkInstanceBrank();
                    }
                }
            }
        }

        private async void checkInstanceBrank()
        {
            if (instaceFullWaitList.Items.Count > 0)
            {
                string? target = instaceFullWaitList.Items[0].ToString();
                if (target != null)
                {
                    if (await sendInvite(target) == 200)
                    {
                        instanceManagerLog.AppendText($"Send Invite to {target} (wait list)\r\n");
                        inviteWaitList.Items.Add(target);
                        guestCount++;
                    }
                }
            }
        }

        private void wsConnect_Click(object sender, EventArgs e)
        {
            wsConnect.Enabled = false;
            webSocketHandler();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }


    public class RootJson
    {
        public string type { get; set; } = null!;
        public string content { get; set; } = null!;
    }

    public class NotificationContent
    {
        public string id { get; set; }

        public string type { get; set; }

        public string senderUserId { get; set; }

        public string senderUsername { get; set; }

        public string receiverUserId { get; set; }

        public string message { get; set; }

        public DateTime created_at { get; set; }
    }

    public class World
    {
        public string id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public bool featured { get; set; }

        public string authorId { get; set; }

        public string authorName { get; set; }

        public int capacity { get; set; }

        public List<string> tags { get; set; }

        public string releaseStatus { get; set; }

        public string imageUrl { get; set; }

        public string thumbnailImageUrl { get; set; }

        public string @namespace { get; set; }

        public int version { get; set; }

        public string organization { get; set; }

        public object previewYoutubeId { get; set; }

        public int favorites { get; set; }

        public int visits { get; set; }

        public int popularity { get; set; }

        public int heat { get; set; }
    }

    public class User
    {
        public string id { get; set; }

        public string displayName { get; set; }

        public string userIcon { get; set; }

        public string bio { get; set; }

        public List<string> bioLinks { get; set; }

        public string profilePicOverride { get; set; }
        public string statusDescription { get; set; }

        public string currentAvatarImageUrl { get; set; }

        public string currentAvatarThumbnailImageUrl { get; set; }

        public string state { get; set; }

        public List<string> tags { get; set; }

        public string developerType { get; set; }

        public DateTime last_login { get; set; }

        public string last_platform { get; set; }

        public bool allowAvatarCopying { get; set; }

        public string status { get; set; }

        public DateTime date_joined { get; set; }

        public bool isFriend { get; set; }

        public string friendKey { get; set; }

        public string last_activity { get; set; }
    }

    public class LocationContent
    {
        public string userId { get; set; }

        public User user { get; set; }

        public string location { get; set; }

        public string travelingToLocation { get; set; }

        public World world { get; set; }

        public bool canRequestInvite { get; set; }
    }

    public class FriendOfflineContent
    { public string userId { get; set; } }
}