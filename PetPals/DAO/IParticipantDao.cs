using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IParticipantDao
    {
        void AddParticipant(Participant participant);
        void RemoveParticipant(int participantID);
        Participant GetParticipantByID(int participantID);
        List<Participant> GetAllParticipants();
    }
}
