namespace Data
{
    public struct Rect
    {
        public Rect(string parameter)
        {
            string[] infos= parameter.Split();
        }
        public Rect(float up, float down, float left, float right)
        {
            this.up = up;
            this.down = down;
            this.left = left;
            this.right = right;
        }
        public float up, down, left, right;
    }
    public struct ImageInfo
    {
        public ImageInfo(string parameter)
        {

        }
        public ImageInfo(float up, float down, float left, float right, float alpha = 0, float angle = 0)
        {
            bounds = new Rect(up, down, left, right);
            this.alpha = alpha;
            this.angle = angle;
        }
        public Rect bounds;
        public float alpha, angle;
    }
}
