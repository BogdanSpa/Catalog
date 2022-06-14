using SharedLibrary.CatalogFeatureException;
using System.Net;
using System.Text.Json;
using SharedLibrary.GradeFeatureException;
using SharedLibrary;
using SharedLibrary.StudentFeatureException;
using SharedLibrary.SubjectFeatureException;

namespace CatalogApplication.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    //Catalog exceptions to status code
                    case SharedLibrary.CatalogFeatureException.CatalogIdDoesNotExistsException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case CatalogIdNotValidException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case GetAllStudentsInternalServerErrorException e:
                        response.StatusCode= (int)HttpStatusCode.InternalServerError;
                        break;
                    case GetAverageForSubjectsInternalServerErrorException e:
                        response.StatusCode=(int)HttpStatusCode.InternalServerError;
                        break;
                    case GetNotesForCatalogInternalServerErrorException e:
                        response.StatusCode =(int)HttpStatusCode.InternalServerError;
                        break;
                    case GetNotesForSubjectInternalServerErrorException e:
                        response.StatusCode=(int)HttpStatusCode.InternalServerError;
                        break;
                    case GetSubjectsForCatalogInternalServerErrorException e:
                        response.StatusCode= (int)HttpStatusCode.InternalServerError;
                        break;
                    case StudentIdValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    //Grade exceptions to status code
                    case AddNoteForStudentInternalServerErrorException e:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                    case AddNoteForStudentModelNotValidException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case SharedLibrary.GradeFeatureException.CatalogIdDoesNotExistsException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case SharedLibrary.GradeFeatureException.InvalidStudentIdException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case SharedLibrary.GradeFeatureException.SubjectIdDoesNotExistsException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    //Student exceptions to status code
                    case ClassNotAssignedToCatalogException e:
                        response.StatusCode=(int)HttpStatusCode.NotFound;
                        break;
                    case GetStudentByClassIsInvalidException e:
                        response.StatusCode =(int)HttpStatusCode.BadRequest;
                        break;
                    case GetStudentsByClassInternalServerErrorException e:
                        response.StatusCode=(int)HttpStatusCode.InternalServerError;
                        break;
                    case GetStudentsWithNotesOnSubjectCatalogInternalServerErrorException e:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                    case GetStudentsWithNotesOnSubjectInvalidException e:
                        response.StatusCode= (int)HttpStatusCode.InternalServerError;
                        break;
                    case SharedLibrary.StudentFeatureException.InvalidStudentIdException e:
                        response.StatusCode=(int)HttpStatusCode.BadRequest;
                        break;
                    case StudentNotFoundForStudentIdException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    //Subject exceptions to status code
                    case AddSubjectToCatalogModelNotValidException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case SharedLibrary.SubjectFeatureException.CatalogIdDoesNotExistsException e:
                        response.StatusCode=(int)HttpStatusCode.NotFound;
                        break;
                    case InsertIntoSubjectCatalogInternalServerErrorException e:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                    case InvalidSubjectIdException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case SubjectCatalogIdNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case SharedLibrary.SubjectFeatureException.SubjectIdDoesNotExistsException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
