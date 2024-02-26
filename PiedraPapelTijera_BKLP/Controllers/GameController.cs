using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PiedraPapelTijera_BKLP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly List<string> opcionesValidas = new List<string> { "piedra", "papel", "tijera" };

        [HttpPost]
        public ActionResult<string> Play(string player1, string player2)
        {
            if (!opcionesValidas.Contains(player1) || !opcionesValidas.Contains(player2))
                return "Al menos una de las opciones ingresadas no es válida.";

            if (player1 == player2)
                return "Empate";

            if ((player1 == "piedra" && player2 == "tijera") ||
                (player1 == "papel" && player2 == "piedra") ||
                (player1 == "tijera" && player2 == "papel"))
                return "Gana jugador 1";

            return "Gana jugador 2";
        }
    }
}
