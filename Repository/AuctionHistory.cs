using Microsoft.EntityFrameworkCore;
using Models.Model;

namespace Repository;

public class AuctionHistory
{
    public interface IAuctionHistoryRepository
    {
        IQueryable<Models.Model.AuctionHistory>  GetAll();
        IQueryable<Models.Model.AuctionHistory> GetById(int id);
        Models.Model.AuctionHistory Create(Models.Model.AuctionHistory auctionHistory);
        public void Update(Models.Model.AuctionHistory auctionHistory);
        public void Delete(Models.Model.AuctionHistory auctionHistory);
    }

    public sealed class AuctionHistoryRepository : IAuctionHistoryRepository
    {
        private readonly KoiFishAuctionDbContext _context;

        public AuctionHistoryRepository(KoiFishAuctionDbContext context)
        {
            _context = context;
        }

        public IQueryable<Models.Model.AuctionHistory> GetAll()
        {
            return  _context.AuctionHistories.AsQueryable();
        }

        public IQueryable<Models.Model.AuctionHistory> GetById(int id)
        {
            return _context.AuctionHistories.Where(x => x.HistoryId == id);
        }

        public Models.Model.AuctionHistory Create(Models.Model.AuctionHistory auctionHistory)
        {
            _context.AuctionHistories.Add(auctionHistory);
            _context.SaveChanges();
            return auctionHistory;
        }

        public void Update(Models.Model.AuctionHistory auctionHistory)
        {
            _context.AuctionHistories.Update(auctionHistory);
            _context.SaveChanges();
        }

        public void Delete(Models.Model.AuctionHistory auctionHistory)
        {
            _context.AuctionHistories.Remove(auctionHistory);
            _context.SaveChanges();
        }
    }
}