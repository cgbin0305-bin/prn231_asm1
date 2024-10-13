using Microsoft.EntityFrameworkCore;
using Models.Model;

namespace Repository;

public class AuctionHistory
{
    public interface IAuctionHistoryRepository
    {
        Task<List<Models.Model.AuctionHistory>> GetAll();
    }

    public sealed class AuctionHistoryRepository : IAuctionHistoryRepository
    {
        private readonly KoiFishAuctionDbContext _context;

        public AuctionHistoryRepository(KoiFishAuctionDbContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Model.AuctionHistory>> GetAll()
        {
            return await _context.AuctionHistories.ToListAsync();
        }
    }
}