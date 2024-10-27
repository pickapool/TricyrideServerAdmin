using MudBlazor;

namespace TricyrideServerAdmin.Models
{
    public class ProgressBarModel
    {
        public string Label { get; set; }
        public int Value { get; set; }
        public Color Color { get; set; } = Color.Success; // Default color
    }
}