﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace EpamSummerPractice.DAL.Interface
{
    public interface IMedalDao
    {
        void Add(Medal medal);
        void Update(int id, Medal medal);
        int Delete(int id);
        Medal ShowById(int id);
        IEnumerable<Medal> GetAll();
    }
}