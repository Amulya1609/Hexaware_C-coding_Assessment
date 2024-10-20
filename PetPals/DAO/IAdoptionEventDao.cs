﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IAdoptionEventDao
    {
        
        AdoptionEvent GetAdoptionEventByID(int eventId);
        void AddAdoptionEvent(AdoptionEvent adoptionEventData);
        void UpdateAdoptionEvent(AdoptionEvent adoptionEventData);
        void DeleteAdoptionEvent(int eventId);
        List<AdoptionEvent> GetAllAdoptionEvents();
        
    }
}
