using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Wrappers
{
public class Response <T>
{
  public Response()
  {

  }
  public Response(T data)
  {
    Succeeded = true;
    StatusMessage = string.Empty;
    Errors = null;
    Data = data;
  }
  public T Data {get;set;}
  public bool Succeeded {get;set;}
  public string[] Errors {get;set;}
  public string StatusMessage{get;set;}
}
}
