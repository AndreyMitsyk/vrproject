﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vra.DataAccess;
using VRA.BusinessLayer;
using VRA.Dto;
using VRA.BusinessLayer.Converters;

namespace VRA.BusinessLayer
{
    public class WorkProcessDb : IWorkProcess
    {
        private readonly IWorkDao _workDao;
        public WorkProcessDb()
        {
            _workDao = DaoFactory.GetWorkDao();
        }
        public IList<WorkDto> GetList()
        {
            return DtoConverter.Convert(_workDao.GetAll());
        }
        public IList<WorkDto> GetListInGallery()
        {
            return DtoConverter.Convert(_workDao.GetInGallery());
        }
        public WorkDto Get(int id)
        {
            return DtoConverter.Convert(_workDao.Get(id));
        }
        public void Add(WorkDto work)
        {
            _workDao.Add(DtoConverter.Convert(work));
        }
        public void Update(WorkDto work)
        {
            _workDao.Update(DtoConverter.Convert(work));
        }
        public void Delete(int id)
        {
            _workDao.Delete(id);
        }
        public IList<WorkDto> SearchWork(string title, string ArtistName, string Copy)
        {
            return DtoConverter.Convert(_workDao.SearchWork(title, ArtistName, Copy));
        }
    }
}
