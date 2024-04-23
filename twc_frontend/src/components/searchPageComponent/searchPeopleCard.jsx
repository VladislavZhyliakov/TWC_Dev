import React, { useState, useEffect } from "react";
import Chip from '@mui/material/Chip';
import Stack from '@mui/material/Stack';
import FaceIcon from '@mui/icons-material/Face';
import BookmarkAddedIcon from '@mui/icons-material/BookmarkAdded';

function fontSizeForTag(label) {
    const baseSize = 16; // Базовий розмір шрифту у пікселях
    const maxTextLength = 10; // Максимальна довжина тексту, при якій шрифт буде найбільший
    const scaleFactor = Math.max(0.75, 1 - (label.length / maxTextLength * 0.5));
    return `calc((1.5vw + 1.5vh)) * ${baseSize * scaleFactor}`;//шиза, треба щось інше
}


const SearchPeopleCard = function () {
    const [userCardPicture, setUserCardPicture] = useState("https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQ3Kpw2-VTvpgvnekgy3PhudjpQ01pzwZYxTzU1YN4NgO1CcW46");
    const [userCardCreds, setUserCardCreds] = useState("Joe Biden");
    const [userGender, setUserGender] = useState("he/him");
    const [userAge, setUserAge] = useState("81");
    const [userTags, setUserTags] = useState(["Terrorists Bombing", "Bald Eagle Praying", "Managing"]);
    const [userAboutText, setUserAboutText] = useState("President of the United States\nMaking America Great Again\nLooking for Donetsk children bombing duties");
    const [userMemberships, setUserMemberships] = useState(["Demencia enjoyers", "Icecream for everyone!"])

    return (
        <div style={{ width: "100%", height: "100%", display: "flex", flexDirection: "column", alignItems: "start" }}>
            <div className="peopleCardHeader">
                <div className="peopleCardUserPic" style={{ backgroundImage: `url(${userCardPicture})` }}></div>
                <div className="peopleCardCreds">
                    {userCardCreds}
                </div>
                <div className="peopleCardGender">
                    {userGender}
                </div>
                <div className="peopleCradAge">
                    {userAge + " y.o."}
                </div>
            </div>
            <div className="peopleCardBody">
                <div className="peopleCardTags">
                    <div className="peopleCardTagsTitle">
                        Tags:
                    </div>

                    <div className="peopleCradTagsChips">
                        <Stack direction="row" spacing={1}>
                            {userTags.map((tag, index) => (
                                <Chip key={index} label={tag}
                                    sx={{
                                        height: "calc((1.5vw + 1.5vh))",
                                        fontFamily: "monospace",
                                        fontSize: fontSizeForTag(tag),
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
                <div className="peopleCardAboutInfo">
                    <div className="peopleCardAboutTitle">
                        About me:
                    </div>
                    <div className="peopleCardAboutText" style={{ whiteSpace: "pre-wrap" }}>
                        {userAboutText}
                    </div>
                </div>
                <div className="peopleCardMemberships">
                    <div className="peopleCardMembershipsTitle">
                        Member:
                    </div>
                    <div className="peopleCardMembershipsChips">
                        <Stack direction="row" spacing={1}>
                            {userMemberships.map((tag, index) => (
                                <Chip icon={<BookmarkAddedIcon />} key={index} label={tag}
                                    sx={{
                                        height: "calc((1.5vw + 1.5vh))",
                                        fontFamily: "monospace",
                                        fontSize: fontSizeForTag(tag),
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

export default SearchPeopleCard;