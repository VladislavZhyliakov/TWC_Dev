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

const LoginCard = function () {

    const [isPassVisible, SetIsPassVisible] = useState(false);
    const [loginValue, SetLoginValue] = useState("");
    const [passValue, SetPassValue] = useState("");

    const OnWrongEmail = function () {
        var message = document.getElementById('loginCardForm_EmailWarning');
        message.style.visibility = "visible";
    }

    const OnWrongPass = function () {
        var message = document.getElementById('loginCardForm_PassWarning');
        message.style.visibility = "visible";
    }

    const handleLoginChange = function(event)
    {
        SetLoginValue(event.target.value);
    }

    const handlePassChange = function(event)
    {
        SetPassValue(event.target.value);
    }

    const showPass = (event) => {
        const input = document.getElementById('loginCardForm_Pass');
        input.type = 'text';
        SetIsPassVisible(true);
    }

    const hidePass = (event) => {
        const input = document.getElementById('loginCardForm_Pass');
        input.type = 'password';
        SetIsPassVisible(false);
    }

    return (
        <div className="loginCardRoot">
            <div className="loginCard">
                <div className="loginCardTitle">
                    Welcome back!
                </div>

                <div className="loginCardForm" style={{marginTop:"3%"}}>
                    <form>
                        <FormControl variant="standard">
                            <InputLabel size="normal" style={{ fontFamily: "monospace", fontWeight: "700", fontSize: "20px" }} shrink htmlFor="loginCardForm_Email">
                                Email:
                            </InputLabel>
                            <CustomInput value={loginValue} onChange={handleLoginChange} id="loginCardForm_Email" />
                            <div className="loginCardForm_inputWarning" id="loginCardForm_EmailWarning">Email error!</div>
                        </FormControl>

                        <FormControl>
                            <InputLabel size="normal" style={{ marginTop: "9%", marginLeft: "-3.5%", fontFamily: "monospace", fontWeight: "700", fontSize: "20px" }} shrink htmlFor="loginCardForm_Pass">
                                Pass:
                            </InputLabel>
                            <CustomInput value={passValue} type='password' onChange={handlePassChange} style={{ marginTop: "13%" }} defaultValue="" id="loginCardForm_Pass" />
                            <div className="loginCardForm_inputWarning" id="loginCardForm_PassWarning">Pass Error!</div>
                        </FormControl>

                        <FormControlLabel style={{ marginTop: "-5px" }}
                            control={<Checkbox />}
                            label="Remember me"
                            sx={{
                                '& .MuiTypography-root': { // Звертання до тексту лейбла
                                    fontFamily: 'monospace', // Ваш шрифт
                                    fontSize: '20', // Розмір шрифту
                                }
                            }}
                        />
                    </form>

                    <div className="loginCardForm_passButton" onMouseDown={(event) => showPass(event)} onMouseUp={(event) => hidePass(event)}>
                        <Icon component={isPassVisible ? RemoveRedEyeOutlinedIcon : VisibilityOffOutlinedIcon} style={{ width: "34px", height: "34px" }} />
                    </div>

                    <CustomButton style={{ width: "50%", height: "16%", marginTop: "10%" }} variant="outlined">Log In</CustomButton>
                    <Link style={{ marginTop: "3%", color: "#0E46A3", cursor: "pointer", fontFamily: "monospace" }}>Forgot Password?</Link>
                </div>
            </div>
        </div>
    );
}

export default LoginCard;