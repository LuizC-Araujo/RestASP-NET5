using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("subtract/{firstNumber}/{secondNumber}")]
        public IActionResult GetSubtract(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var subtract = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(subtract.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("multiply/{firstNumber}/{secondNumber}")]
        public IActionResult GetMultiply(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var multiply = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(multiply.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult GetDivision(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var division = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(division.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("squareroot/{number}")]
        public IActionResult GetSquareRoot(string number)
        {
            if (IsNumeric(number))
            {
                var squareRoot = ConvertToDecimal(number) * ConvertToDecimal(number);
                return Ok(squareRoot.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("media/{firstNumber}/{secondNumber}/{thirdNumber}")]
        public IActionResult GetMedia(string firstNumber, string secondNumber, string thirdNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber) && IsNumeric(thirdNumber))
            {
                var media = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber) + ConvertToDecimal(thirdNumber)) / 3;
                return Ok(media.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            if (decimal.TryParse(strNumber, out decimal decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private static bool IsNumeric(string strNumber)
        {
            return double.TryParse(strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out _);
        }
    }
}
