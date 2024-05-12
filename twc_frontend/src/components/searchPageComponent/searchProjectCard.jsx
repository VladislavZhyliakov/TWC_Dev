import React, { useState, useEffect } from "react";
import Chip from '@mui/material/Chip';
import Stack from '@mui/material/Stack';
import FaceIcon from '@mui/icons-material/Face';

const SearchProjectCard = function () {
    const [cardTitle, setCardTitle] = useState("Hacking Pentagon");
    const [cardTags, setCardTags] = useState(["HTML", "Hacking", "Cybersecurity"]);
    const [cardProjectType, setProjectType] = useState("Educational");
    const [cardProjectDescription, setCardProjectDescription] = useState("Hack Pentagon with HTML (very legal) for Biden to give Ukraine 5 billion rockets to bomb Donetsk childen.");
    const [cardProjectMaxMembers, setCardProjectMaxMembers] = useState(5);
    const [cardProjectMembers, setCardProjectMembers] = useState(["Jonathan Smith", "Mathew Matt", "Andy Sad"]);
    const [cardBackGroundImage, setCardBackgroundImage] = useState("https://cdn.britannica.com/85/94185-050-B3B95F6F/view-Pentagon-Arlington-Va.jpg");

    return (
        <div style={{ width: "100%", height: "100%" }}>
            <div className="projectCardHeader" style={{backgroundImage:`linear-gradient(to bottom, rgba(240, 248, 255, 0) 50%, rgba(240, 248, 255, 1) 100%), url(${cardBackGroundImage})`}}>

            </div>

            <div className="projectCardBody">
                <div className="projectCardTitle">
                    {cardTitle}
                </div>

                <div className="projectCardTags">
                    <div className="projectCardsTagsHeader">
                        Tags:
                    </div>
                    <div className="projectCardsTagsChips">
                        <Stack direction="row" spacing={1}>
                            {cardTags.map((tag, index) => (
                                <Chip key={index} label={tag}
                                    sx={{
                                        height: "calc((1.5vw + 1.5vh))",
                                        fontFamily: "monospace",
                                        fontSize: "calc((1.5vw + 1.5vh) / 2)",
                                        '& .MuiChip-label': {
                                            display: 'block',
                                            whiteSpace: 'normal',
                                        },
                                    }}
                                />
                            ))}
                        </Stack>
                    </div>
                </div>

                <div className="projectCardType">
                    <div className="projectCardsTypeHeader">
                        Project Type:
                    </div>
                    <div className="projectCardTypeText">
                        {cardProjectType}
                    </div>
                </div>

                <div className="projectCardDescription">
                    <div className="projectCardsDescriptionHeader">
                        Description:
                    </div>
                    <div className="projectCardDescriptionText">
                        {cardProjectDescription}
                    </div>
                </div>

                <div className="projectCardMembers">
                    <div className="projectCardsTagsHeader">
                        {"Members (" + cardProjectMembers.length + "/" + cardProjectMaxMembers + "):"}
                    </div>

                    <div className="projectCardTypeText">
                        <Stack direction="row" spacing={1}>
                            {cardProjectMembers.map((tag, index) => (
                                <Chip icon={<FaceIcon/>} key={index} label={tag} variant="outlined" 
                                    sx={{
                                        height: "calc((1.5vw + 1.5vh))",
                                        fontFamily: "monospace",
                                        fontSize: "calc((1.0vw + 1.0vh) / 2)",
                                        '& .MuiChip-label': {
                                            display: 'block',
                                            whiteSpace: 'normal',
                                        },
                                    }}
                                />
                            ))}
                        </Stack>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default SearchProjectCard;