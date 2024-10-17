"use client";

import { useTheme } from 'next-themes';
import { SunIcon } from "@heroicons/react/24/outline";
import { BsMoonStars } from "react-icons/bs"
import { useEffect, useState } from 'react';

export default function ThemeToggler() {
    const { theme, setTheme } = useTheme();
    const [mounted, setMounted] = useState(false);

    useEffect(() => {
        setMounted(true);
    }, []);

    if (!mounted) return null;

    return (
        <button
            onClick={() => setTheme(theme === "dark" ? "light" : "dark")}
        >
            {theme === "dark" ? (
                <SunIcon className="h-8 w-8 text-orange-400" />
            ) : (
                <BsMoonStars className="h-6 w-6 rounded-full text-gray-100" />
            )}
        </button>
    );
}