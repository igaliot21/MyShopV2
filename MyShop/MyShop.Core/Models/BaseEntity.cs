using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public abstract class BaseEntity
    {
        private string id;
        private DateTimeOffset createdAt;
        public BaseEntity() {
            this.id = Guid.NewGuid().ToString();
            this.createdAt = DateTime.Now;
        }
        public string Id{
            get { return this.id; }
        }
        public DateTimeOffset CreatedAt{
            get { return this.createdAt; }
        }
    }
}
