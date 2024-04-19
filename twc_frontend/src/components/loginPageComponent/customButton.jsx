import React from "react";
import Button from '@mui/material/Button';
import { alpha, styled } from '@mui/material/styles';

const CustomButton = styled(Button)({
    boxShadow: 'none',
    textTransform: 'none',
    fontSize: 24,
    border: '2px solid',
    lineHeight: 1.5,
    borderColor: 'black',
    color: 'black',
    fontFamily: [
        'monospace',
    ].join(','),
    '&:hover': {
        backgroundColor: '#9BB0C1',
        borderColor: '#9BB0C1',
        color: 'white',
        boxShadow: 'none',
    },
    '&:active': {
        boxShadow: 'none',
        backgroundColor: 'black',
        borderColor: '#9BB0C1',
    },
    '&:focus': {
    },
});

export default CustomButton;