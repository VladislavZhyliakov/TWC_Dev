import React, { useState } from "react";
import { alpha, styled } from '@mui/material/styles';
import InputBase from '@mui/material/InputBase';
import InputLabel from '@mui/material/InputLabel';
import FormControl from '@mui/material/FormControl';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import Button from '@mui/material/Button';
import Link from '@mui/material/Link';
import Icon from '@mui/material/Icon'
import RemoveRedEyeOutlinedIcon from '@mui/icons-material/RemoveRedEyeOutlined';
import VisibilityOffOutlinedIcon from '@mui/icons-material/VisibilityOffOutlined';
import '../../styles/loginpage_styles.css'
import { FormLabel } from "@mui/material";
import CustomInput from "./customInput";
import CustomButton from "./customButton";
import CustomInputSignIn from "./customInputSignIn";

const SignInCard = function () {
    const [isPassVisible, SetIsPassVisible] = useState(false);
    const [usernameValue, SetUsernameValue] = useState("");
    const [loginValue, SetLoginValue] = useState("");
    const [passValue, SetPassValue] = useState("");
    const [confirmPassValue, SetConfirmPassValue] = useState("");

    const OnWrongEmail = function () {
        var message = document.getElementById('loginCardForm_EmailWarning');
        message.style.visibility = "visible";
    }

    const OnWrongPass = function () {
        var message = document.getElementById('loginCardForm_PassWarning');
        message.style.visibility = "visible";
    }

    const handleUsernameChange = function (event) {
        SetUsernameValue(event.target.value);
    }

    const handleLoginChange = function (event) {
        SetLoginValue(event.target.value);
    }

    const handlePassChange = function (event) {
        SetPassValue(event.target.value);
    }

    const handleConfirmPassChange = function (event) {
        SetConfirmPassValue(event.target.value);
    }

    const showPass = (event) => {
        const passInput = document.getElementById('signInCardForm_Pass');
        const confirmPassInput = document.getElementById('signInCardForm_ConfirmPass');
        passInput.type = 'text';
        confirmPassInput.type = 'text';
        SetIsPassVisible(true);
    }

    const hidePass = (event) => {
        const passInput = document.getElementById('signInCardForm_Pass');
        const confirmPassInput = document.getElementById('signInCardForm_ConfirmPass');
        passInput.type = 'password';
        confirmPassInput.type = 'password';
        SetIsPassVisible(false);
    }

    return (
        <div className="loginCardRoot">
            <div className="loginCard" style={{ marginTop: "-10%" }}>
                <div className="loginCardTitle">
                    Welcome!
                </div>

                <div className="loginCardForm">
                    <form style={{ height: "90%" }}>
                        <FormControl variant="standard" style={{ height: "25%"}}>
                            <InputLabel size="normal" style={{ fontFamily: "monospace", fontWeight: "700", fontSize: 'calc((1.7vw + 1.7vh) / 2)' }} shrink htmlFor="signinCardForm_UserName">
                                User name:
                            </InputLabel>
                            <CustomInputSignIn value={usernameValue} onChange={handleUsernameChange} id="signinCardForm_UserName" style={{ marginTop: "6%", fontSize: 'calc((1.7vw + 1.7vh) / 2.5)'}} />
                            <div className="loginCardForm_inputWarning" id="loginCardForm_EmailWarning" style={{marginTop:"-1%"}}>UserName Error!</div>
                        </FormControl>

                        <FormControl variant="standard" style={{ height: "25%"}}>
                            <InputLabel size="normal" style={{ fontFamily: "monospace", fontWeight: "700", fontSize: 'calc((1.7vw + 1.7vh) / 2)' }} shrink htmlFor="signinCardForm_Email">
                                Email:
                            </InputLabel>
                            <CustomInputSignIn value={loginValue} onChange={handleLoginChange} id="signinCardForm_Email" style={{ marginTop: "6%",  fontSize: 'calc((1.7vw + 1.7vh) / 2.5)' }} />
                            <div className="loginCardForm_inputWarning" id="loginCardForm_EmailWarning" style={{ marginTop:"-1%"}}>Email error!</div>
                        </FormControl>

                        <FormControl variant="standard" style={{ height: "25%"}}>
                            <InputLabel size="normal" style={{fontFamily: "monospace", fontWeight: "700", fontSize: 'calc((1.7vw + 1.7vh) / 2)' }} shrink htmlFor="signInCardForm_Pass">
                                Password:
                            </InputLabel>
                            <CustomInputSignIn value={passValue} type='password' onChange={handlePassChange} defaultValue="" id="signInCardForm_Pass" style={{ marginTop: "6%", fontSize: 'calc((1.7vw + 1.7vh) / 2.5)' }} />

                            <div className="loginCardForm_passButton" style={{ marginTop: "6.9%" }} onMouseDown={(event) => showPass(event)} onMouseUp={(event) => hidePass(event)}>
                                <Icon component={isPassVisible ? RemoveRedEyeOutlinedIcon : VisibilityOffOutlinedIcon} style={{ width: 'calc((2vw + 2vh) / 1.7)', height: 'calc((2vw + 2vh) / 1.7)', filter:"invert(1)"}} />
                            </div>

                            <div className="loginCardForm_inputWarning" id="loginCardForm_PassWarning" style={{visibility:"hidden", marginTop:"-1%"}}>Pass Error!</div>
                        </FormControl>

                        <FormControl variant="standard" style={{ height: "25%"}}>
                            <InputLabel size="normal" style={{fontFamily: "monospace", fontWeight: "700", fontSize: 'calc((1.7vw + 1.7vh) / 2)' }} shrink htmlFor="signInCardForm_ConfirmPass">
                                Confirm Password:
                            </InputLabel>
                            <CustomInputSignIn value={confirmPassValue} type='password' onChange={handleConfirmPassChange} defaultValue="" id="signInCardForm_ConfirmPass" style={{ marginTop: "6%", fontSize: 'calc((1.7vw + 1.7vh) / 2.5)' }} />
                            <div className="loginCardForm_inputWarning" style={{ marginTop:"-1%"}} id="loginCardForm_PassWarning">Pass Error!</div>
                        </FormControl>
                    </form>

                    <CustomButton style={{ width: "50%", height: "16%", marginTop: "2%", fontSize: 'calc((3.0vw + 3.0vh) / 3)' }} variant="outlined">Sign In</CustomButton>
                </div>
            </div>
        </div>
    );
}

export default SignInCard;