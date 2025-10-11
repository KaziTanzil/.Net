using DAL.EF;

namespace DAL.Repos
{
    public class Repo
    {
        protected UMSContext db;
        public Repo()
        {
            db = new UMSContext();
        }
    }
}
