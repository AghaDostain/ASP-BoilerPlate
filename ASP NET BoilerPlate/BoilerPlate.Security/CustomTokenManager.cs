using BoilerPlate.Data;
using BoilerPlate.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BoilerPlate.Security
{
    public class CustomTokenManager : IDisposable
    {
        private DataContext Context;
        public CustomTokenManager(DataContext context)
        {
            this.Context = context ?? new DataContext();
        }
        public async Task<bool> AddAsync(RefreshToken token)
        {
            var existingToken = await Context.RefreshTokens.Where(r => r.Subject == token.Subject && r.ClientId == token.ClientId).FirstOrDefaultAsync();
            if (existingToken != null)
            {
                var result = await DeleteAsync(existingToken);
            }
            Context.RefreshTokens.Add(token);
            return await Context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteAsync(string refreshTokenId)
        {
            var refreshToken = await Context.RefreshTokens.Where(x => x.Token == refreshTokenId).FirstOrDefaultAsync();
            if (refreshToken != null)
            {
                Context.RefreshTokens.Remove(refreshToken);
                return await Context.SaveChangesAsync() > 0;
            }
            return false;
        }
        public async Task<bool> DeleteAsync(RefreshToken refreshToken)
        {
            Context.RefreshTokens.Remove(refreshToken);
            return await Context.SaveChangesAsync() > 0;
        }
        public void Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }
            this.Context = null;
        }
        public async Task<RefreshToken> FindAsync(string refreshTokenId)
        {
            var refreshToken = Context.RefreshTokens.Where(x => x.Token == refreshTokenId).FirstOrDefault();
            return await Task.FromResult<RefreshToken>(refreshToken);
        }
        public async Task<List<RefreshToken>> GetAsync()
        {
            return await Context.RefreshTokens.ToListAsync();
        }
    }
}