﻿using FortniteStats.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FortniteStats.Logic
{
    public class GetDataLogic
    {
        public async static Task<GetStats> GetUserStats(string username)
        {
            

            var urlid = Data.GenerateURLID(username);


            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(urlid);
                    var json = await response.Content.ReadAsStringAsync();

                    if (json.Contains(" \"error\": true"))
                    {
                        //THE METHOD SHOULD STOP HERE IF THERE IS A PROBLEM AND THE USER COULD NOT BE FOUND.
                        GetStats error = new GetStats();
                        error.uid = "error";
                        return error;
                    }

                    var idroot = JsonConvert.DeserializeObject<GetID>(json);


                    var urlstats = Data.GenerateURLStats(idroot.uid, idroot.platforms[0]);

                    var responsenew = await client.GetAsync(urlstats);
                    var jsonstats = await responsenew.Content.ReadAsStringAsync();
                    var statsroot = new GetStats();
                    statsroot = JsonConvert.DeserializeObject<GetStats>(jsonstats);

                    //we manually transfer the seasons and platforms because we cannot return two objects.

                    //BUUUUT IT IS CRASHING SO WE WILL REVIEW IT AGAIN LATER...


                    statsroot.platforms = idroot.platforms;
                    //statsroot.GetID.seasons = idroot.seasons;


                    return statsroot;
                }
            }
            catch (Exception e)
            {
                
                GetStats error = new GetStats();
                error.uid = "errornointernet";
                return error;
            }
            
            }
                

        }
    }

