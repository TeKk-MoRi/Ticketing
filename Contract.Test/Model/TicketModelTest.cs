using Contract.Query.Ticket;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Test.Model
{
    public static class TicketModelTest
    {
        public class TicketModelRequestTest : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {
                    new GetAllTicketsQuery(new Messaging.Ticket.GetAllTicketsRequest { Owner = "Test"})
                };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }
}
