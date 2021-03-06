﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointRobertsSoftware.StarTrek.Models;
using PointRobertsSoftware.StarTrek.Messages;
using System.Threading;

namespace StarTrek
{
    public sealed class Enterprise
    {
        private KnownGalaxy _knownGalaxy = null;
        private EnterpriseRealityQueue _enterpriseRealityQueue = null;
        //private Thread _myThread;
        private Communication _comm;


        public Enterprise()
        {
            _knownGalaxy = new KnownGalaxy();
            var realityQueue = new RealityQueue();
            _enterpriseRealityQueue = new EnterpriseRealityQueue(realityQueue);
            realityQueue.ReceiveMessageInQueue += OnRealityQueueActivity;
            _comm = new Communication();
            //_myThread = new Thread(_comm.Start)
            //{
            //    IsBackground = true
            //};
            //_myThread.Start(realityQueue);
        }

        public KnownGalaxy KnownGalaxy => _knownGalaxy;

        public EnterpriseRealityQueue EnterpriseRealityQueue => _enterpriseRealityQueue;

        public void OnRealityQueueActivity(object sender, EventArgs e)
        {
            IMessage message = _enterpriseRealityQueue.GetMessage();
            if (message.MessageType == MessageType.QuadrantSummaryMessage)
            {
                HandleQuadrantSummaryMessage((QuadrantSummaryMessage)message);
            }
            else if (message.MessageType == MessageType.QuadrantDetailMessage)
            {
                // TODO
            }
            else
            {
                throw new ArgumentOutOfRangeException("MessageType", string.Format("MessageType of {0} is not implemented.", message.MessageType));
            }
        }

        private void HandleQuadrantSummaryMessage(QuadrantSummaryMessage message)
        {
            for (int row=0; row<8; row++)
            {
                for (int col = 0 ; col < 8; col++)
                {
                    Quadrant q = KnownGalaxy.GetQuadrant(row, col);
                    QuadrantSummary qs = message.Summary.FirstOrDefault(s => s.QuadrantX == row && s.QuadrantY == col);
                    if ( qs == null)
                    {
                        q.SetQuadrantToInactive();
                    }
                    else
                    {
                        q.SetQuadrantSummaryValues(qs.NumberOfStars, qs.NumberOfBases, qs.NumberOfEnemies);
                    }
                }
            }
        }
    }
}
