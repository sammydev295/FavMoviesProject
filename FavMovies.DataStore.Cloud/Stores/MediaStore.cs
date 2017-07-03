using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using MoreLinq;

using Sealegs.DataStore.Abstractions;
using Sealegs.DataObjects;
using Sealegs.DataStore.Azure;

namespace Sealegs.DataStore.Azure
{
    public class LockerMemberStore : BaseStore<LockerMember>, ILockerMemberStore
    {
        #region Properties

        public override string Identifier => "Lockers";

        #endregion

        #region ILockerMemberStore implementation

        public async Task<IEnumerable<LockerMember>> GetAllLockerMembers(bool forceRefresh = false)
        {
            await InitializeStore().ConfigureAwait (false);
           
            if (forceRefresh)
                await PullLatestAsync().ConfigureAwait (false);

            var lockers = await Table.ToListAsync().ConfigureAwait(false);

            // Adjust image path
            lockers.ForEach(l => l.ProfileImage = $"{base.ImagesURI}/{l.LockerImageUri.AbsolutePath}");
            return lockers;
        }

        public async Task<LockerMember> GetSingleLockerMember(int id)
        {
            var locker = await Table.LookupAsync(id.ToString());
            return locker;
        }

        #endregion
    }
}

