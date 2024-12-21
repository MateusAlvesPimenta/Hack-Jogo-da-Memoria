namespace CardCapture;

public class CardScreenshot
{
    private readonly MouseEventArgs _mouseEventArgs;

    private struct Card
    {
        public int StartX;
        public int StartY;
        public string Number;
    }

    public CardScreenshot(MouseEventArgs mouseEventArgs)
    {
        _mouseEventArgs = mouseEventArgs;
    }

    public void TakeScreenShot()
    {
        // Tira um novo screenshot tendo o width e height de uma carta como atributos
        // Utilizando resolução 1366 por 768
        Bitmap screenshot = new Bitmap(width: 70, height: 80);

        Card card = FindCard();

        // Recorta a região da imagem desejada, no caso a região na qual se encontra a carta
        using (Graphics g = Graphics.FromImage(screenshot))
        {
            g.CopyFromScreen(card.StartX, card.StartY, 0, 0, new Size(70, 80));
        }

        // Salva o screenshot com o numero da carta que foi capturada
        screenshot.Save($"../Frontend/public/img/Card{card.Number}.jpg");
    }

    private Card FindCard()
    {
        Card card = new Card();

        // Descobrirá a altura na qual o mouse clicou (Y), após descobrir isso a 
        // cordenada "StartY" será atualizada devidamente.
        // "Number" é nada mais nd menos do q YX, sendo Y a linha na qual o mouse clicou
        // e X a coluna. O tabuleiro do jogo possui 5 cartas de altura e 6 de largura, 
        // a função deste primeiro filtro é descobrir a linha do clique e atualizar 
        // "Number" devidamente.

        if (_mouseEventArgs.Y <= 218)
        {
            card.StartY = 138;
            card.Number += 0;
        }
        else if (_mouseEventArgs.Y >= 224 && _mouseEventArgs.Y <= 304)
        {
            card.StartY = 224;
            card.Number += 1;
        }
        else if (_mouseEventArgs.Y >= 310 && _mouseEventArgs.Y <= 390)
        {
            card.StartY = 310;
            card.Number += 2;
        }
        else if (_mouseEventArgs.Y >= 396 && _mouseEventArgs.Y <= 476)
        {
            card.StartY = 396;
            card.Number += 3;
        }
        else
        {
            card.StartY = 482;
            card.Number += 4;
        }

        // Mesma função do primeiro filtro, mas este é para achar o "X", 
        // no caso a coluna que ocorreu o clique

        if (_mouseEventArgs.X <= 463)
        {
            card.StartX = 393;
            card.Number += 0;
        }
        else if (_mouseEventArgs.X >= 467 && _mouseEventArgs.X <= 537)
        {
            card.StartX = 467;
            card.Number += 1;
        }
        else if (_mouseEventArgs.X >= 541 && _mouseEventArgs.X <= 611)
        {
            card.StartX = 541;
            card.Number += 2;
        }
        else if (_mouseEventArgs.X >= 615 && _mouseEventArgs.X <= 685)
        {
            card.StartX = 615;
            card.Number += 3;
        }
        else if (_mouseEventArgs.X >= 689 && _mouseEventArgs.X <= 759)
        {
            card.StartX = 689;
            card.Number += 4;
        }
        else
        {
            card.StartX = 763;
            card.Number += 5;
        }

        return card;
    }
}