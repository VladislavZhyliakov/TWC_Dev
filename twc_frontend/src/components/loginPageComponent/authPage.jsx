import React, {useState} from "react";
import '../../styles/loginpage_styles.css'

import LoginCard from "./loginCard";
import SignInCard from "./signInCard";

const AuthPage = function()
{
    const [showLoginCard, setShowLoginCard] = useState(true);

    const OnNavBarLoginButtonClick = function()
    {
        document.getElementById('authCardNavBarButton_logIn').style.backgroundColor = 'white';
        document.getElementById('authCardNavBarButton_signIn').style.backgroundColor = 'black';

        document.getElementById('authCardNavBarButton_logInText').style.color = "black";
        document.getElementById('authCardNavBarButton_signInText').style.color = "white";

        setShowLoginCard(true);
    }

    const OnNavBarSigInButtonClick = function()
    {
        document.getElementById('authCardNavBarButton_logIn').style.backgroundColor = 'black';
        document.getElementById('authCardNavBarButton_signIn').style.backgroundColor = 'white';

        document.getElementById('authCardNavBarButton_logInText').style.color = "white";
        document.getElementById('authCardNavBarButton_signInText').style.color = "black";

        setShowLoginCard(false);
    }

    return(
        <div className="authPageRoot">
            <div className="authPage">
                <div className="authCard">
                    <div className="authCardNavBar">
                        <div id="authCardNavBarButton_logIn" onClick={OnNavBarLoginButtonClick} className="authCardNavBarButton">
                            <div id="authCardNavBarButton_logInText" className="authCardNavBarButtonText" style={{color:"black"}}>Log In</div>
                        </div>
                        <div id="authCardNavBarButton_signIn" onClick={OnNavBarSigInButtonClick} className="authCardNavBarButton">
                            <div id="authCardNavBarButton_signInText" className="authCardNavBarButtonText" style={{color:"white"}}>Sign In</div>
                        </div>
                    </div>

                    {/*probably not the best idea, better solution is to use Routing*/}
                    {showLoginCard ? <LoginCard/> : <SignInCard/>}
                </div>

            </div>
        </div>
    );
}

export default AuthPage;