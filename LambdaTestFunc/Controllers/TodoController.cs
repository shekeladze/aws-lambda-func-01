﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace LambdaTestFunc.Controllers
{
    [Route("api/Todo")]
    public class TodoController : Controller
    {
        private IMemoryCache _cache;

        public TodoController(IMemoryCache memCache)
        {
            _cache = memCache;
        }


        [HttpGet]
        public IEnumerable<string> Get()
        {   
            return new string[] { "buy milk", "walk dog", "call mom", "wash car", "buy medicine", "wash hands", "brush teeth", "buy ticket", "call dad",
                "use existing api" };
        }

        [HttpPost]
        public IEnumerable<string> Post(string someData)
        {
            return new string[] { "posted response" };
        }

        [HttpGet("EnvTest")]
        public IActionResult EnvTest()
        {
            const string CACHED_DATA = "CACHED_DATA";

            var envVar = Environment.GetEnvironmentVariable("SOME_VAR");
            
            string cachedStr;
            var readFromCache = _cache.TryGetValue(CACHED_DATA, out cachedStr);

            if (!readFromCache)
            {
                // Key not in cache, so get data.
                cachedStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                //// Set cache options.
                //var cacheEntryOptions = new MemoryCacheEntryOptions()
                //    // Keep in cache for this time, reset time if accessed.
                //    .SetSlidingExpiration(TimeSpan.FromSeconds(3));

                // Save data in cache.
                _cache.Set(CACHED_DATA, cachedStr, DateTime.Now.AddMinutes(30));
            }

            return Ok(new { readFromCache, cachedValue = cachedStr });
        }

    }
}