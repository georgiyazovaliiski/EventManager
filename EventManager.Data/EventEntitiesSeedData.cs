using EventManager.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.Data
{
    public class EventEntitiesSeedData : DropCreateDatabaseIfModelChanges<EventEntities>
    {
        protected override void Seed(EventEntities context)
        {
            GetEvents().ForEach(e => context.Events.Add(e));

            context.Commit();
        }

        private static List<Event> GetEvents()
        {
            return new List<Event>
            {
                new Event {
                    Name = "BG Radio Awards",
                    Location = "Blagoevgrad, Bulgaria",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now
                },
                new Event {
                    Name = "NeverSea",
                    Location = "Romania",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(5)
                },
                new Event {
                    Name = "Skillet Concert",
                    Location = "Sofia, Bulgaria",
                    StartDate = DateTime.Now.AddDays(19),
                    EndDate = DateTime.Now.AddDays(20)
                }
            };
        }
        }
    }
