using TestNinja.Fundamentals;

namespace NinjaNet.Tests;

public class ReservationTests
{

    [Test]
    public void CanBeCancelledBy_AdminCencelling_ReturnsTrue()
    {
        var resorvation = new Reservation();
        var result = resorvation.CanBeCancelledBy(new User { IsAdmin = true });
        Assert.IsTrue(result);
    }

    [Test]
    public void CanBeCencelledBy_SameUserCancellingTheResirvation_Returntrue()
    {
        var user = new User();
        var reservation = new Reservation { MadeBy = user };
        var result = reservation.CanBeCancelledBy(user);
        Assert.IsTrue(result);
    }

    [Test]
    public void CanBeCamcelledBy_AnotherUserCencellingReservation_ReturnFalse()
    {
        var reservation = new Reservation();
        var result = reservation.CanBeCancelledBy(new User());
        Assert.IsFalse(result);
    }
}


