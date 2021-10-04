﻿using Eventhings.DbContexts;
using Eventhings.DbEntities;
using Eventhings.Dto;
using Eventhings.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace Eventhings.Services
{
    /// <summary>
    /// Summary description for events
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    public class events : System.Web.Services.WebService
    {

        [WebMethod]
        public List<EventResponse> Get()
        {
            var response = new List<EventResponse>();

            try
            {
                using (var _context = new EventhingsDbContext())
                {
                    var query = _context.tcoreevents
                        .Where(e => e.active == 1 && e.deleted == 0)
                        .Select(n => new EventResponse() 
                        {
                            id = n.id,
                            name = n.name,
                            description = n.description,
                            location = n.location,
                            active = n.active,
                            deleted = n.deleted,
                            Status = 1,
                            duration = n.duration,
                            start_date = n.start_date,
                            host_id = n.host_id,
                            end_date = n.end_date,
                            created_at = n.created_at,
                            created_by = n.created_by
                        }).ToList();

                    foreach(var ss in query)
                    {
                        response.Add(ss);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Add(new EventResponse()
                {
                    Status = 0,
                    Message = ex.ToString()
                });
            }

            return response;
        }

        [WebMethod]
        public HostResponse Save(HostDto hostdto)
        {
            var response = new HostResponse();

            try
            {
                using (var _context = new EventhingsDbContext())
                {

                    var query = _context.tcorehosts.Where(name => name.full_name == hostdto.full_name || name.phone == hostdto.phone).FirstOrDefault();
                    if (query != null)
                    {
                        response.Status = 0;
                        response.Message = "The host specified already exists";
                        return response;
                    }
                    else
                    {
                        _context.tcorehosts.Add(new tcorehost
                        {
                            full_name = hostdto.full_name,
                            description = hostdto.description,
                            phone = hostdto.phone,
                            email = hostdto.email,
                            address = hostdto.address,
                            deleted = hostdto.deleted,
                            active = hostdto.active,
                            created_by = hostdto.created_by,
                            created_at = DateTime.Now,
                        });

                        var affected = _context.SaveChanges();

                        if (affected > 0)
                        {
                            response.Status = affected;
                            response.Message = $"{affected} Event created successfuly, switch to 'Manage Event' tab to view it";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.Status = 0;
                response.Message = ex.ToString();
            }

            return response;
        }
    }
}
