using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Moq;
using MoqIt = Moq.It;
using ThenIt = Machine.Specifications.It;
using PicasaUploader.Commands;

namespace PicasaUploader.Tests
{
    [Subject("User")]
    public class User_can_login
    {
        static LoginCommand loginCommand;
        static bool loggedIn;

        Establish with_a_valid_user = () => {
            var picasaMock = new Mock<IMediaUploadService>();
            picasaMock.Setup(controller => controller.Login(MoqIt.IsAny<string>(), MoqIt.IsAny<string>())).Returns(true);

            loginCommand = new LoginCommand(picasaMock.Object);
        };

        Because of = () => {
            loggedIn = loginCommand.Login("user", "password");
        };

        ThenIt should_be_logged_in = () => {
            loggedIn.ShouldBeTrue();
        };
    }
}
