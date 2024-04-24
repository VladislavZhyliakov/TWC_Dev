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

    const handleLoginChange = function (event) {
        SetLoginValue(event.target.value);
    }

    const handlePassChange = function (event) {
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

                <div className="loginCardForm" style={{ marginTop: "3%"}}>
                    <form style={{height:"60%"}}>
                        <FormControl variant="standard" style={{height:"40%"}}>
                            <InputLabel size="normal" style={{ fontFamily: "monospace", fontWeight: "700", fontSize: 'calc((1.7vw + 1.7vh) / 2)' }} shrink htmlFor="loginCardForm_Email">
                                Email:
                            </InputLabel>
                            <CustomInput value={loginValue} onChange={handleLoginChange} id="loginCardForm_Email" style={{ fontSize: 'calc((1.7vw + 1.7vh) / 2.5)' }} />
                            <div className="loginCardForm_inputWarning" id="loginCardForm_EmailWarning">Email error!</div>
                        </FormControl>

                        <FormControl variant="standard" style={{height:"40%", marginTop:"5%"}}>
                            <InputLabel size="normal" style={{fontFamily: "monospace", fontWeight: "700", fontSize: 'calc((1.7vw + 1.7vh) / 2)' }} shrink htmlFor="loginCardForm_Pass">
                                Pass:
                            </InputLabel>
                            
                            <CustomInput value={passValue} type='password' onChange={handlePassChange} style={{fontSize: 'calc((1.7vw + 1.7vh) / 2.5)', float:"left" }} defaultValue="" id="loginCardForm_Pass" />
                            
                            <div className="loginCardForm_passButton" onMouseDown={(event) => showPass(event)} onMouseUp={(event) => hidePass(event)}>
                                <Icon component={isPassVisible ? RemoveRedEyeOutlinedIcon : VisibilityOffOutlinedIcon} style={{ width: 'calc((2vw + 2vh) / 1.7)', height: 'calc((2vw + 2vh) / 1.7)', filter:"invert(1)"}} />
                            </div>
                            
                            <div className="loginCardForm_inputWarning" id="loginCardForm_PassWarning" style={{visibility:"hidden"}}>Pass Error!</div>
                        </FormControl>

                        <FormControlLabel style={{ height:"calc((1.6vw + 1.6vh) / 1)", marginTop:"calc((1.6vw + 1.6vh) / 2.8)"}}
                            control={<Checkbox />}
                            label="Remember me"
                            sx={{
                                '& .MuiTypography-root': { // Звертання до тексту лейбла
                                    fontFamily: 'monospace', // Ваш шрифт
                                    fontSize: 'calc((1.5vw + 1.5vh) / 2)', // Розмір шрифту
                                }
                            }}
                        />
                    </form>

                    <CustomButton style={{ width: "50%", height: "16%", marginTop: "18%", fontSize: 'calc((3.0vw + 3.0vh) / 3)' }} variant="outlined">Log In</CustomButton>
                    <Link style={{ marginTop: "3%", color: "#0E46A3", cursor: "pointer", fontFamily: "monospace", fontSize: 'calc((1.5vw + 1.5vh) / 3)' }}>Forgot Password?</Link>
                </div>
            </div>
        </div>
    );
}

export default LoginCard;