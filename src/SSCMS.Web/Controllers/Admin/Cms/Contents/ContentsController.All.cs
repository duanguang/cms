﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSCMS.Dto.Request;
using SSCMS.Dto.Result;
using SSCMS.Utils;

namespace SSCMS.Web.Controllers.Admin.Cms.Contents
{
    public partial class ContentsController
    {
        [HttpPost, Route(RouteAll)]
        public async Task<ActionResult<BoolResult>> All([FromBody] AllRequest request)
        {
            
            if (!await _authManager.IsAdminAuthenticatedAsync() ||
                !await _authManager.HasSitePermissionsAsync(request.SiteId,
                    Constants.SitePermissions.Contents))
            {
                return Unauthorized();
            }

            var site = await _siteRepository.GetAsync(request.SiteId);
            if (site == null) return NotFound();

            var channel = await _channelRepository.GetAsync(request.ChannelId);
            channel.IsAllContents = request.IsAllContents;
            await _channelRepository.UpdateAsync(channel);

            return new BoolResult
            {
                Value = true
            };
        }

        public class AllRequest : ChannelRequest
        {
            public bool IsAllContents { get; set; }
        }
    }
}
