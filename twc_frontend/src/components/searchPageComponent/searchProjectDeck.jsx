import React, { useState, useEffect } from "react";
import '../../styles/searchpage_styles.css'

import { useSprings, animated, to as interpolate } from '@react-spring/web'
import { useDrag } from 'react-use-gesture'
import SearchProjectCard from "./searchProjectCard";

const cards = [
    'https://upload.wikimedia.org/wikipedia/commons/f/f5/RWS_Tarot_08_Strength.jpg',
    'https://upload.wikimedia.org/wikipedia/commons/5/53/RWS_Tarot_16_Tower.jpg',
    'https://upload.wikimedia.org/wikipedia/commons/9/9b/RWS_Tarot_07_Chariot.jpg',
    'https://upload.wikimedia.org/wikipedia/commons/d/db/RWS_Tarot_06_Lovers.jpg',
    'https://upload.wikimedia.org/wikipedia/commons/thumb/8/88/RWS_Tarot_02_High_Priestess.jpg/690px-RWS_Tarot_02_High_Priestess.jpg',
    'https://upload.wikimedia.org/wikipedia/commons/d/de/RWS_Tarot_01_Magician.jpg',
];

const to = (i) => ({
    x: i * 4,
    y: i * 4,
    scale: 1,
    rot: -10 + Math.random() * 20,
    delay: i * 100,
});
const from = (_i) => ({ x: 0, rot: 0, scale: 1.5, y: -1000 });
const trans = (r, s) =>
    `perspective(1500px) rotateX(0deg) rotateY(${r / 100}deg) rotateZ(${r / 20}deg) scale(${s})`;

function Deck() {
    const [gone] = useState(() => new Set());
    const [props, api] = useSprings(cards.length, (i) => ({
        ...to(i),
        from: from(i),
    }));

    const bind = useDrag(({ args: [index], down, movement: [mx], direction: [xDir], velocity }) => {
        const trigger = velocity > 2.0;
        const dir = xDir < 0 ? -1 : 1;
        if (!down && trigger) gone.add(index);
        api.start((i) => {
            if (index !== i) return;
            const isGone = gone.has(index);
            const x = isGone ? (200 + window.innerWidth) * dir : down ? mx : 0;
            const rot = mx / 100 + (isGone ? dir * 10 * velocity : 0);
            const scale = down ? 1.1 : 1;
            return {
                x,
                rot,
                scale,
                delay: undefined,
                config: { friction: 50, tension: down ? 800 : isGone ? 200 : 500 },
            };
        });
        if (!down && gone.size === cards.length)
            setTimeout(() => {
                gone.clear();
                api.start((i) => to(i));
            }, 600);
    });

    return (
        <>
            {props.map(({ x, y, rot, scale }, i) => (
                <animated.div className="searchProjectsCardSwaper" key={i} style={{ x, y }}>
                    <animated.div className="searchProjectsCard"
                        {...bind(i)}
                        style={{
                            transform: interpolate([rot, scale], trans)
                        }}
                    >
                        <SearchProjectCard/>
                    </animated.div>
                </animated.div>
            ))}
        </>
    );
}

const SearchProjectDeck = function () {
    return (
        <div className="searchProjectsCardContainer">
            <Deck></Deck>
        </div>
    )
}

export default SearchProjectDeck;