using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using PointRobertsSoftware.StarTrek.Messages;

namespace StarTrek
{
    public class Communication
    {
        private CommunicationRealityQueue _commRealityQueue;

        public void Start(object realityQueue)
        {
            _commRealityQueue = new CommunicationRealityQueue((RealityQueue)realityQueue);

            // Create a message
            var testMessage = new QuadrantSummaryMessage
            {
                MessageType = MessageType.QuadrantSummaryMessage,
                Summary = new List<QuadrantSummary> {
                    new QuadrantSummary { QuadrantX = 0, QuadrantY = 0, NumberOfStars = 0, NumberOfEnemies = 0 },
                    new QuadrantSummary { QuadrantX = 1, QuadrantY = 0, NumberOfStars = 1, NumberOfEnemies = 0 },
                    new QuadrantSummary { QuadrantX = 2, QuadrantY = 0, NumberOfStars = 2, NumberOfEnemies = 0 },
                    new QuadrantSummary { QuadrantX = 0, QuadrantY = 1, NumberOfStars = 0, NumberOfEnemies = 1 },
                    new QuadrantSummary { QuadrantX = 1, QuadrantY = 1, NumberOfStars = 1, NumberOfEnemies = 1 },
                    new QuadrantSummary { QuadrantX = 2, QuadrantY = 1, NumberOfStars = 2, NumberOfEnemies = 1 }
                }
            };

            _commRealityQueue.EnqueueReceive(testMessage);
        }
    }
}
