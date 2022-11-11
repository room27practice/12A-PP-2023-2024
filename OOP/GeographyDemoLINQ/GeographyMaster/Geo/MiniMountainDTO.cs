namespace Geo
{
    public class MiniMountainDTO
    {
        public MiniMountainDTO(int peakHeight, string peakName, string mountainName)
        {
            PeakHeight = peakHeight;
            PeakName = peakName;
            MountainName = mountainName;
        }
        public MiniMountainDTO()
        {

        }
        public int PeakHeight { get; set; }
        public string PeakName { get; set; }
        public string MountainName { get; set; }
    }
}
