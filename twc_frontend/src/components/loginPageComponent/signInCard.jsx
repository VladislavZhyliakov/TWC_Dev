import React, {useState} from "react";
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

const SignInCard = function()
{
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

    const handleUsernameChange = function(event)
    {
        SetUsernameValue(event.target.value);
    }

    const handleLoginChange = function(event)
    {
        SetLoginValue(event.target.value);
    }

    const handlePassChange = function(event)
    {
        SetPassValue(event.target.value);
    }

    const handleConfirmPassChange = function(event)
    {
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

    return(
        <div className="loginCardRoot">
            <div className="loginCard" style={{marginTop:"-10%"}}>
                <div className="loginCardTitle">
                    Welcome!
                </div>

                <div className="loginCardForm">
                    <form>
                        <FormControl variant="standard">
                            <InputLabel size="normal" style={{ fontFamily: "monospace", fontWeight: "700", fontSize: "20px" }} shrink htmlFor="signinCardForm_UserName">
                                User name:
                            </InputLabel>
                            <CustomInput value={usernameValue} onChange={handleUsernameChange} id="signinCardForm_UserName" />
                            <div className="loginCardForm_inputWarning" id="loginCardForm_EmailWarning">Email error!</div>
                        </FormControl>

                        <FormControl variant="standard">
                            <InputLabel size="normal" style={{ fontFamily: "monospace", fontWeight: "700", fontSize: "20px" }} shrink htmlFor="signinCardForm_Email">
                                Email:
                            </InputLabel>
                            <CustomInput value={loginValue} onChange={handleLoginChange} id="signinCardForm_Email" />
                            <div className="loginCardForm_inputWarning" id="loginCardForm_EmailWarning">Email error!</div>
                        </FormControl>

                        <FormControl>
                            <InputLabel size="normal" style={{ marginTop: "2%", marginLeft: "-3.5%", fontFamily: "monospace", fontWeight: "700", fontSize: "20px" }} shrink htmlFor="signInCardForm_Pass">
                                Password:
                            </InputLabel>
                            <CustomInput value={passValue} type='password' onChange={handlePassChange} style={{ marginTop: "6%" }} defaultValue="" id="signInCardForm_Pass" />
                            <div className="loginCardForm_inputWarning" id="loginCardForm_PassWarning">Pass Error!</div>
                        </FormControl>

                        <FormControl>
                            <InputLabel size="normal" style={{ marginTop: "2%", marginLeft: "-3.5%", fontFamily: "monospace", fontWeight: "700", fontSize: "20px" }} shrink htmlFor="signInCardForm_RepeatPass">
                                Confirm Password:
                            </InputLabel>
                            <CustomInput value={confirmPassValue} type='password' onChange={handleConfirmPassChange} style={{ marginTop: "6%" }} defaultValue="" id="signInCardForm_ConfirmPass" />
                            <div className="loginCardForm_inputWarning" id="loginCardForm_PassWarning">Pass Error!</div>
                        </FormControl>
                    </form>

                    <div className="loginCardForm_passButton" style={{marginTop:"13.7%"}} onMouseDown={(event) => showPass(event)} onMouseUp={(event) => hidePass(event)}>
                        <Icon component={isPassVisible ? RemoveRedEyeOutlinedIcon : VisibilityOffOutlinedIcon} style={{ width: "34px", height: "34px" }} />
                    </div>

                    <CustomButton style={{ width: "50%", height: "16%", marginTop: "2%" }} variant="outlined">Sign In</CustomButton>
                </div>
            </div>
        </div>
    );
}

export default SignInCard;