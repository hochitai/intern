using Quiz.DataStore;
using Quiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Services
{
    public class LevelService
    {
        private readonly LevelStore levelStore;

        public LevelService(LevelStore levelStore)
        {
            this.levelStore = levelStore;
        }

        public bool AddLevel(Level level)
        {
            return levelStore.Add(level);
        }

        public List<Level> GetLevelsByTopicId(int topicId)
        {
            return levelStore.GetLevelsByTopicId(topicId);
        }

    }
}
