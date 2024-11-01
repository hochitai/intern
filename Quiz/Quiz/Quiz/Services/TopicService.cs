using Quiz.DataStore;
using Quiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Services
{
    public class TopicService
    {
        private readonly TopicStore _topicStore;

        public TopicService(TopicStore _topicStore)
        {
            _topicStore = _topicStore;
        }

        public bool AddTopic(Topic topic) 
        {
            return _topicStore.AddTopic(topic);
        }

        public List<Topic> GetAllTopics() 
        {
            return _topicStore.GetAllTopics();
        }


    }
}
