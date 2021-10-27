
namespace lab5
{
    public class UserInfo
    {
        private string _name;
        private string _status;
        private string _image;
        private string _lastseen;
        private string _another;

        public void SetName(string name) { _name = name; }
        public void SetStatus(string status) { _status = status; }
        public void SetImage(string image) { _image = image; }
        public void SetLastSeen(string lastseen) { _lastseen = lastseen; }
        public void SetAnother(string another) { _another = another; }

        public string Name => _name;
        public string Status => _status;
        public string Image => _image;
        public string LastSeen => _lastseen;
        public string Another => _another;
    }
}

