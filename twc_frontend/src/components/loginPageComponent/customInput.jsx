import React from "react";
import InputBase from '@mui/material/InputBase';
import { alpha, styled } from '@mui/material/styles';

const CustomInput = styled(InputBase)(({ theme }) => ({
    'label + &': {
        marginTop: theme.spacing(3),
    },
    '& .MuiInputBase-input': {
        borderRadius: 4,
        position: 'relative',
        backgroundColor: theme.palette.mode === 'light' ? '#F3F6F9' : '#1A2027',
        border: '2px solid',
        borderColor: theme.palette.mode === 'black' ? '#E0E3E7' : '#2D3843',
        fontSize: "100%",
        fontWeight: 600,
        width: '16.6vw',
        padding: '1.1vh 1.4vw',
        transition: theme.transitions.create([
            'border-color',
            'background-color',
            'box-shadow',
        ]),
        fontFamily: [
            'monospace'
        ].join(','),
        '&:focus': {
            boxShadow: `${alpha(theme.palette.primary.main, 0.25)} 0 0 0 0.2rem`,
            borderColor: theme.palette.primary.main,
        },
    },
}));

export default CustomInput;