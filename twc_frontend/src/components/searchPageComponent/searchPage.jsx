import React, { useState, useEffect } from "react";
import '../../styles/searchpage_styles.css'
import TopNavBar from "../topNavBarComponent/topNavBar";
import SearchProjectDeck from "./searchProjectDeck";
import SearchPeopleDeck from "./searchPeopleDeck";

const SEARCH_TYPE_ENUM = {
    PROJECT: 'project', 
    PEOPLE: 'people'
};

const SearchPage = function () {
    {/*the searchType parameter we will get from parent component or localStorage*/}
    const [searchType, SetSearchType] = useState(SEARCH_TYPE_ENUM.PEOPLE);

    return (
        <div>
            <TopNavBar></TopNavBar>
            <div className="searchPageRoot">
                <div className="searchPage">
                    <div className="searchPageLeftField">
                        <div className="searchPageLeftButton"></div>
                    </div>
                    <div className="searchPageCardField">
                       {searchType === SEARCH_TYPE_ENUM.PROJECT && <SearchProjectDeck/>}
                       {searchType === SEARCH_TYPE_ENUM.PEOPLE && <SearchPeopleDeck/>}
                    </div>
                    <div className="searchPageRightField">
                        <div className="searchPageRightButton"></div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default SearchPage;