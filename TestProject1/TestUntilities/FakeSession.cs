using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASC.Utilities;
using ASC.Web;
using Microsoft.AspNetCore.Http;


namespace ASC.Tests.Testutilities
{
    public class FakeSession : ISession
    {
        public bool IsAvailable => throw new NotImplementedException();

        public string Id => throw new NotImplementedException();

        public IEnumerable<string> Keys => throw new NotImplementedException();
        private Dictionary<string, byte[]> SessionFactory = new Dictionary<string, byte[]>();

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }
        public Task LoadAsync()
        {
            throw new NotImplementedException();
        }
        private Dictionary<string, byte[]> sessionFactory = new Dictionary<string, byte[]>();
        public void Set(string key, byte[] value)
        {
            throw new NotImplementedException();
        }
        public bool TryGetValue(string key, out byte[] value)
        {
            if (sessionFactory.ContainsKey(key) && sessionFactory[key] != null)
            {
                value = sessionFactory[key];
                return true;
            }
            else
            {
                value = null;
                return false;
            }
        }

        public Task LoadAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        //public Task LoadAsync(CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task CommitAsync(CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Remove(string key)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
