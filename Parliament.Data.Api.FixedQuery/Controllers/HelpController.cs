﻿namespace Parliament.Data.Api.FixedQuery.Controllers
{
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web;
    using System.Web.Http;

    [RoutePrefix("")]
    public class IndexController : ApiController
    {
        [Route()]
        public HttpResponseMessage Get()
        {
            var links = new string[] {
                this.Url.Route("PersonIndex", null),
                this.Url.Route("PersonById", new { id = "s732vwcz" }),
                this.Url.Route("PersonByInitial", new { initial = "ö" }),
                this.Url.Route("PersonLookup", new { source = "mnisId", id = "3299" }),
                this.Url.Route("PersonByLetters", new { letters = "ee" }),
                this.Url.Route("PersonAToZ", null),
                this.Url.Route("PersonConstituencies", new { id = "s732vwcz" }),
                this.Url.Route("PersonCurrentConstituency", new { id = "s732vwcz" }),
                this.Url.Route("PersonParties", new { id = "epQBV83d" }),
                this.Url.Route("PersonCurrentParty", new { id = "epQBV83d" }),
                this.Url.Route("PersonContactPoints", new { id = "jYuUOvWN" }),
                this.Url.Route("PersonHouses", new { id = "jYuUOvWN" }),
                this.Url.Route("PersonCurrentHouse", new { id = "jYuUOvWN" }),

                // MemberIndex route exists on person controller
                this.Url.Route("MemberIndex", null),

                this.Url.Route("MemberCurrent", null),
                this.Url.Route("MemberByInitial", new { initial = "y" }),
                this.Url.Route("MemberCurrentByInitial", new { initial = "z" }),
                this.Url.Route("MemberAToZ", null),
                this.Url.Route("MemberCurrentAToZ", null),

                
                this.Url.Route("ConstituencyIndex", null),
                this.Url.Route("ConstituencyByID", new { id = "jDWN9S5g" }),
                this.Url.Route("ConstituencyByInitial", new { initial = "l" }),
                this.Url.Route("ConstituencyCurrent", null),
                this.Url.Route("ConstituencyLookup", new { source = "onsCode", id = "E14000699" }),
                this.Url.Route("ConstituencyByLetters", new { letters = "heath" }),
                this.Url.Route("ConstituencyCurrentByInitial", new { initial = "v" }),
                this.Url.Route("ConstituencyAToZ", null),
                this.Url.Route("ConstituencyCurrentAToZ", null),
                this.Url.Route("ConstituencyMembers", new { id = "h6RPrGWq" }),
                this.Url.Route("ConstituencyCurrentMember", new { id = "h6RPrGWq" }),
                this.Url.Route("ConstituencyContactPoint", new { id = "h6RPrGWq" }),
                this.Url.Route("ConstituencyLookupByPostcode", new { postcode = "sw1p 3ja"}),


                this.Url.Route("PartyIndex", null),
                this.Url.Route("PartyById", new { id = "1H0bLjgL" }),
                this.Url.Route("PartyByInitial", new { initial = "a" }),
                this.Url.Route("PartyCurrent", null),
                this.Url.Route("PartyByLetters", new { letters = "zeb" }),
                this.Url.Route("PartyAToZ", null),
                this.Url.Route("PartyCurrentAToZ", null),
                this.Url.Route("PartyLookup", new { source = "mnisId", id = "231" }),
                this.Url.Route("PartyMembers", new { id = "hdP5hB37"}),
                this.Url.Route("PartyCurrentMembers", new { id = "hdP5hB37"}),
                this.Url.Route("PartyMembersByInitial", new { id = "hdP5hB37", initial = "f"}),
                this.Url.Route("PartyMembersAToZ", new { id = "hdP5hB37" }),
                this.Url.Route("PartyCurrentMembersByInitial", new { id = "hdP5hB37", initial = "z"}),
                this.Url.Route("PartyCurrentMembersAToZ", new { id = "hdP5hB37" }),


                this.Url.Route("HouseIndex", null),
                this.Url.Route("HouseById", new { id = "u5dbuRBD" }),
                this.Url.Route("HouseLookup", new { source = "name", id = "House of Lords" }),
                this.Url.Route("HouseByLetters", new { letters = "house" }),
                this.Url.Route("HouseMembers", new { id = "u5dbuRBD"}),
                this.Url.Route("HouseCurrentMembers", new { id = "u5dbuRBD"}),
                this.Url.Route("HouseParties", new { id = "u5dbuRBD"}),
                this.Url.Route("HouseCurrentParties", new { id = "u5dbuRBD"}),
                this.Url.Route("HousePartyById", new { houseid = "u5dbuRBD", partyid = "jMNf7IDk"}),
                this.Url.Route("HouseMembersByInitial", new { houseid = "u5dbuRBD", initial = "m"}),
                this.Url.Route("HouseMembersAToZ", new { id = "u5dbuRBD" }),
                this.Url.Route("HouseCurrentMembersByInitial", new { houseid = "u5dbuRBD", initial = "m"}),
                this.Url.Route("HouseCurrentMembersAToZ", new { id = "u5dbuRBD" }),
                this.Url.Route("HousePartyMembers", new { houseid = "u5dbuRBD", partyid = "jMNf7IDk"}),
                this.Url.Route("HousePartyMembersByInitial", new { houseid = "u5dbuRBD", partyid = "jMNf7IDk", initial = "c"}),
                this.Url.Route("HousePartyMembersAToZ", new { houseid = "u5dbuRBD", partyid = "jMNf7IDk"}),
                this.Url.Route("HousePartyCurrentMembers", new { houseid = "u5dbuRBD", partyid = "jMNf7IDk"}),
                this.Url.Route("HousePartyCurrentMembersByInitial", new { houseid = "u5dbuRBD", partyid = "jMNf7IDk", initial = "f"}),
                this.Url.Route("HousePartyCurrentMembersAToZ", new { houseid = "u5dbuRBD", partyid = "jMNf7IDk"}),


                this.Url.Route("ContactPointIndex", null),
                this.Url.Route("ContactPointById", new { id = "Ne6xySIb" })


            };

            var response = Request.CreateResponse();

            response.Content = new StringContent($@"
<!DOCTYPE html>
<html>
    <head>
        <meta charset='utf-8'>
    </head>
    <body>
        <ul>{string.Join(string.Empty, from link in links select $"<li><a href='{link}'>{HttpUtility.UrlDecode(link).Substring(this.Configuration.VirtualPathRoot.Length)}</a></li>")}</ul>
    </body>
</html>
");

            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");

            return response;
        }
    }
}