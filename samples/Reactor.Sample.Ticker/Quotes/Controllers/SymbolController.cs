using Microsoft.AspNetCore.Mvc;
using Reactor.Core.Stores;
using Reactor.Sample.Ticker.Quotes.Actions;
using Reactor.Sample.Ticker.Quotes.Dtos;

namespace Reactor.Sample.Ticker.Quotes.Controllers
{
    [Route("quotes/symbols")]
    public class SymbolController : Controller
    {
        private readonly Store<State> _store;

        public SymbolController(Store<State> store)
        {
            _store = store;
        }

        [HttpPost("")]
        public IActionResult AddSymbol([FromBody] AddSymbolDto dto)
        {
            _store.Dispatch(new AddSymbolAction(dto.Symbol));
            return Ok();
        }
    }
}
