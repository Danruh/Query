﻿namespace Parliament.Data.Api.FixedQuery.Controllers
{
    using System;
    using System.Web.Http;
    using VDS.RDF;
    using VDS.RDF.Query;

    public partial class FixedQueryController 
    {
        //[Route("", Name = "ContactPointIndex")]
        [HttpGet]
        public Graph contact_point_index()
        {
            var queryString = @"
PREFIX : <http://id.ukpds.org/schema/>
CONSTRUCT {
    ?contactPoint
        a :ContactPoint ;
        :email ?email ;
        :phoneNumber ?phoneNumber ;
        :faxNumber ?faxNumber ;
        :contactPointHasPostalAddress ?postalAddress .
    ?postalAddress 
        a :PostalAddress ;
        :postCode ?postCode ;
        :addressLine1 ?addressLine1 ;
        :addressLine2 ?addressLine2 ;
        :addressLine3 ?addressLine3 ;
        :addressLine4 ?addressLine4 ;
        :addressLine5 ?addressLine5 .
}
WHERE {
    ?contactPoint a :ContactPoint .
    OPTIONAL{ ?contactPoint :email ?email . }
    OPTIONAL{ ?contactPoint :phoneNumber ?phoneNumber . }
    OPTIONAL{ ?contactPoint :faxNumber ?faxNumber . }
    OPTIONAL{
        ?contactPoint :contactPointHasPostalAddress ?postalAddress .
        OPTIONAL{ ?postalAddress :postCode ?postCode . }
        OPTIONAL{ ?postalAddress :addressLine1 ?addressLine1 . }
        OPTIONAL{ ?postalAddress :addressLine2 ?addressLine2 . }
        OPTIONAL{ ?postalAddress :addressLine3 ?addressLine3 . }
        OPTIONAL{ ?postalAddress :addressLine4 ?addressLine4 . }
        OPTIONAL{ ?postalAddress :addressLine5 ?addressLine5 . }
    }
}
";

            var query = new SparqlParameterizedString(queryString);

            return BaseController.ExecuteList(query);
        }

        //[Route(@"{id:regex(^\w{8}$)}", Name = "ContactPointById")]
        [HttpGet]
        public Graph contact_point_by_id(string contact_point_id)
        {
            var queryString = @"
PREFIX :<http://id.ukpds.org/schema/>
CONSTRUCT {
    ?contactPoint
        a :ContactPoint ;
        :email ?email ;
        :phoneNumber ?phoneNumber ;
        :faxNumber ?faxNumber ;
        :contactPointHasPostalAddress ?postalAddress ;
        :contactPointHasIncumbency ?incumbency .
    ?incumbency
        a :Incumbency ;
        :incumbencyHasMember ?person .
    ?postalAddress
        a :PostalAddress ;
        :postCode ?postCode ;
        :addressLine1 ?addressLine1 ;
        :addressLine2 ?addressLine2 ;
        :addressLine3 ?addressLine3 ;
        :addressLine4 ?addressLine4 ;
        :addressLine5 ?addressLine5 .
    ?person
        a :Person ;
        :personGivenName ?givenName ;
        :personFamilyName ?familyName ;
        <http://example.com/F31CBD81AD8343898B49DC65743F0BDF> ?displayAs .
}
WHERE {
    BIND(@id AS ?contactPoint )
    ?contactPoint a :ContactPoint .
    OPTIONAL{ ?contactPoint :email ?email . }
    OPTIONAL{ ?contactPoint :phoneNumber ?phoneNumber . }
    OPTIONAL{ ?contactPoint :faxNumber ?faxNumber . }
    OPTIONAL{
        ?contactPoint :contactPointHasPostalAddress ?postalAddress .
        OPTIONAL{ ?postalAddress :postCode ?postCode . }
        OPTIONAL{ ?postalAddress :addressLine1 ?addressLine1 . }
        OPTIONAL{ ?postalAddress :addressLine2 ?addressLine2 . }
        OPTIONAL{ ?postalAddress :addressLine3 ?addressLine3 . }
        OPTIONAL{ ?postalAddress :addressLine4 ?addressLine4 . }
        OPTIONAL{ ?postalAddress :addressLine5 ?addressLine5 . }
	}
    OPTIONAL{
        ?contactPoint :contactPointHasIncumbency ?incumbency .
        ?incumbency :incumbencyHasMember ?person .
        OPTIONAL { ?person :personFamilyName ?familyName . }
        OPTIONAL { ?person :personGivenName ?givenName . }
        OPTIONAL { ?person <http://example.com/F31CBD81AD8343898B49DC65743F0BDF> ?displayAs } .
	}
}
";

            var query = new SparqlParameterizedString(queryString);

            query.SetUri("id", new Uri(instance, contact_point_id));

            return BaseController.ExecuteSingle(query);
        }
    }
}