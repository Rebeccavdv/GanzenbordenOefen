using Ganzenbord;
using NUnit.Framework;


namespace GanzenbordOpdrachtTest;

public class Tests
{
    private Dobbelsteen testDobbelsteen;
    private Speler testSpeler;
    private Spel testSpel;

    [SetUp]
    public void Setup()
    {
        testDobbelsteen = new Dobbelsteen();
        testSpeler = new Speler("TestSpeler");
        testSpel = new Spel();
    }

    [Test]
    public void Dobbelsteen_IsTussen1En6()
    {
        var waarde = testDobbelsteen.Gooi();
        Assert.That(waarde, Is.InRange(1, 6));
    }

    [Test]
    public void Speler_StartPositieIs0()
    {
        Assert.That(testSpeler.Positie, Is.EqualTo(0));
    }

    [Test]
    public void Speler_VerplaatstCorrect()
    {
        testSpeler.Verplaats(3);
        Assert.That(testSpeler.Positie, Is.EqualTo(3));
    }

    [Test]
    public void Speler_GaatNietVoorbijEindVakje()
    {
        testSpeler.Verplaats(65); // Als de speler 65 vakjes verplaatst, moet hij terugkaatsen vanaf vakje 63
        Assert.That(testSpeler.Positie, Is.EqualTo(61)); // 65 - 63 = 2, dus hij komt uit op 63 - 2 = 61
    }

    [Test]
    public void Speler_KomtOpGansVakjeEnVerplaatstNogmaals()
    {
        testSpeler.Verplaats(5); // Verplaatst naar een gans vakje
        int oudePositie = testSpeler.Positie;
        testSpel.Bord[testSpeler.Positie].Actie(testSpeler);
        Assert.That(testSpeler.Positie, Is.Not.EqualTo(oudePositie)); // De speler moet nogmaals verplaatst zijn
    }

    [Test]
    public void BrugVakje_VerplaatstCorrect()
    {
        testSpeler.Verplaats(6); // Verplaatst naar brugvakje
        testSpel.Bord[testSpeler.Positie].Actie(testSpeler);
        Assert.That(testSpeler.Positie, Is.EqualTo(12)); // De speler moet naar vakje 12 verplaatst worden
    }

    [Test]
    public void HerbergVakje_SlaatBeurtOver()
    {
        testSpeler.Verplaats(19); // Verplaatst naar herbergvakje
        testSpel.Bord[testSpeler.Positie].Actie(testSpeler);
        Assert.That(testSpeler.BeurtenOverslaan, Is.EqualTo(1)); // De speler moet 1 beurt overslaan
    }

    [Test]
    public void PutVakje_BlokkeertSpeler()
    {
        testSpeler.Verplaats(31); // Verplaatst naar putvakje
        testSpel.Bord[testSpeler.Positie].Actie(testSpeler);
        Assert.That(testSpeler.BeurtenOverslaan, Is.EqualTo(int.MaxValue)); // De speler moet wachten tot hij wordt bevrijd
    }

    [Test]
    public void EindVakje_SpelWintCorrect()
    {
        testSpeler.Verplaats(63); // Verplaatst naar eindvakje
        testSpel.Bord[testSpeler.Positie].Actie(testSpeler);
        Assert.That(testSpeler.Positie, Is.EqualTo(63)); // Controleer of de speler op het eindvakje staat
    }
}
