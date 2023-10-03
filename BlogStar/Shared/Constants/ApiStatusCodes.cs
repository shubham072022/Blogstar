using System.Net;

namespace BlogStar.Shared.Constants
{
    public static class ApiStatusCodes
    {
        public static int Accepted => Convert.ToInt32(HttpStatusCode.Accepted);

        public static int Ok => Convert.ToInt32(HttpStatusCode.OK);

        public static int BadRequest => Convert.ToInt32(HttpStatusCode.BadRequest);
        
        public static int NotFound => Convert.ToInt32(HttpStatusCode.NotFound);

        public static int InternalServerError => Convert.ToInt32(HttpStatusCode.InternalServerError);

        public static int NoContent => Convert.ToInt32(HttpStatusCode.NoContent);

        public static int Created => Convert.ToInt32(HttpStatusCode.Created);

        public static int Forbidden => Convert.ToInt32(HttpStatusCode.Forbidden);

        public static int UnAuthorized => Convert.ToInt32(HttpStatusCode.Unauthorized);

        public static int MethodNotAllowed => Convert.ToInt32(HttpStatusCode.MethodNotAllowed);
    }
}
