using System;
using Moq;
using TestNinja.Mocking;
using TestNinjaNet.Mocking;

namespace NinjaNet.Tests.Mocking
{
	public class HouseKeeperServiceTests
	{
		private HouseKeeperService _service;
		private Mock<IStatementGenerator> _statementGenerator;
		private Mock<IEmailSender> _emailSender;
		private Mock<IXtraMessageBox> _messageBox;
		private DateTime _statementDate = new DateTime(2017,1,1);
        private Housekeeper _houseKeeper;
        private string _statementFileName;


		[SetUp]
		public void SetUp()
		{
            _houseKeeper = new Housekeeper { Email = "a", FullName = "b", Oid = 1, StatementEmailBody = "c" };

            var unitOfWork = new Mock<IUnitOfWork>();
			
            unitOfWork.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
				_houseKeeper

            }.AsQueryable());


            _statementFileName = "fileName";
            _statementGenerator = new Mock<IStatementGenerator>();
            _statementGenerator
               .Setup(sg => sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, (_statementDate)))
          .Returns(() => _statementFileName);

            _emailSender = new Mock<IEmailSender>();
            _messageBox = new Mock<IXtraMessageBox>();

            _service = new HouseKeeperService(
                unitOfWork.Object,
                _statementGenerator.Object,
                _emailSender.Object,
                _messageBox.Object);
        }


		[Test]
		public void SendStatementEmails_WhenCalled_GenetateStatements()
		{
		
			_service.SendStatementEmails(_statementDate);
			 
			_statementGenerator.Verify(sg=>
			sg.SaveStatement(_houseKeeper.Oid,_houseKeeper.FullName,(_statementDate)));
		}



        [Test]
        public void SendStatementEmails_HouseKeepersEmailIsNull_ShouldNotGenetateStatement()
        {
            _houseKeeper.Email = null;
            _service.SendStatementEmails(_statementDate);

            _statementGenerator.Verify(sg =>
            sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, (_statementDate)),
            Times.Never);
        }



        [Test]
        public void SendStatementEmails_HouseKeepersEmailsWhitespace_ShouldNotGenetateStatement()
        {
            _houseKeeper.Email = " ";
            _service.SendStatementEmails(_statementDate);

            _statementGenerator.Verify(sg =>
            sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, (_statementDate)),
            Times.Never);
        }




        [Test]
        public void SendStatementEmails_HouseKeepersEmailIsEmpty_ShouldNotGenetateStatement()
        {
            _houseKeeper.Email = " ";
            _service.SendStatementEmails(_statementDate);

            _statementGenerator.Verify(sg =>
            sg.SaveStatement(_houseKeeper.Oid, _houseKeeper.FullName, (_statementDate)),
            Times.Never);
        }




        [Test]
        public void SendStatementEmails_WhenCalled_EmailTheStatement()
        {
            _service.SendStatementEmails(_statementDate);
            VerifyEmailSent();
        }

       

        [Test]
        public void SendStatementEmails_StatementFileNameIsNull_ShouldNotEmailTheStatement()
        {
            _statementFileName = null;
            _service.SendStatementEmails(_statementDate);

            VerifyEmailNotSent();
        }


        [Test]
        public void SendStatementEmails_StatementFileIsEmptyString_ShouldNotEmailTheStatement()
        {
            _statementFileName = "";
            _service.SendStatementEmails(_statementDate);

            VerifyEmailNotSent();
        }

       

        [Test]
        public void SendStatementEmails_StatementFileNameIsWhiteSpace_ShouldNotEmailTheStatement()
        {

            _statementFileName = " ";
            _service.SendStatementEmails(_statementDate);

            VerifyEmailNotSent();
        }

        [Test]
        public void SendStatementEmails_EmailSendingFails_DisplayAMessageBox()
        {
            _emailSender.Setup(es => es.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()
                )).Throws<Exception>();

            _service.SendStatementEmails(_statementDate);
            _messageBox.Verify(mb => mb.Show(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButtons.OK));
           
        }



        private void VerifyEmailNotSent()
        {
            _emailSender.Verify(es => es.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
                Times.Never);
        }


        private void VerifyEmailSent()
        {
            _emailSender.Verify(es => es.EmailFile(
                _houseKeeper.Email,
                _houseKeeper.StatementEmailBody,
                _statementFileName,
                It.IsAny<string>()));
        }
    }
}

