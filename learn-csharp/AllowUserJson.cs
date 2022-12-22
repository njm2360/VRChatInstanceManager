using System.Text.Json;
using System.Windows.Forms;

namespace learn_csharp
{
    internal class AllowUserJson
    {
        private MainForm fm;
        private const string ConfigFileName = "allowList.json";
        public string[] staffList = { };

        public AllowUserJson(MainForm fm)
        {
            this.fm = fm;
        }

        internal void loadAllowUsers()
        {
            if (File.Exists(ConfigFileName))
            {
                using (FileStream fs = File.OpenRead(ConfigFileName))
                {
                    using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.UTF8))
                    {
                        while (!sr.EndOfStream)
                        {
                            AllowUserJsonContent allowUser = JsonSerializer.Deserialize<AllowUserJsonContent>(sr.ReadToEnd());

                            foreach (var id in allowUser.users)
                            {
                                fm.allowUserList.Items.Add(id);
                            }

                            staffList = allowUser.users;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("許可リストJSONがありません");
            }
        }
    }

    public class AllowUserJsonContent
    {
        public string[] users { get; set; }
    }
}
