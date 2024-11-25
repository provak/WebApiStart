using Microsoft.AspNetCore.Mvc;

public class TestController : BaseController
{
  [HttpGet("test")]
  public string GetHelloWorldText()
  {
    return "Hello World!";
  }

  // [HttpGet("test-request")]
  // public ActionResult<string> TestRequest()
  // {
  //   return BadRequest("Hello World");
  // }
}
