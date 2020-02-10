namespace KlasifikavimasXY
{
    class ObjectTrainer
    {
        private int x1;
        private int x2;
        private string className;
        private double distance;
        public ObjectTrainer(int x1, int x2, string className)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.className = className;
        }
        public ObjectTrainer() { }
        public int X1
        {
            get { return x1; }
            set { this.x1 = value; }
        }
        public int X2
        {
            get { return x2; }
            set { this.x2 = value; }
        }
        public string ClassName
        {
            get { return className; }
            set { this.className = value; }
        }
        public double Distance
        {
            get { return distance; }
            set { this.distance = value; }
        }
        public string fullInfo
        {
            get
            {
                return $"{this.x1} {this.x2} {this.className}";
            }
        }
    }
}
