"use client";

import { useTheme } from 'next-themes';
import { SunIcon } from "@heroicons/react/24/outline";
import { BsMoonStars } from "react-icons/bs";
import * as ToggleGroup from "@radix-ui/react-toggle-group";
import { useEffect, useState } from 'react';

export default function ThemeToggler() {
    const { theme, setTheme } = useTheme();
    const [mounted, setMounted] = useState(false);

    useEffect(() => {
        setMounted(true);
    }, []);

    useEffect(() => {
        if (mounted) {
            document.documentElement.setAttribute('data-theme', theme);
        }
    }, [theme, mounted]);

    if (!mounted) return null;

    return (
        <div className="flex justify-center items-center mt-4">
            <ToggleGroup.Root
                type="single"
                defaultValue={theme}
                value={theme}
                onValueChange={(value) => setTheme(value)}
                className="flex rounded-lg overflow-hidden "
            >
                <ToggleGroup.Item
                    value="light"
                    className={`p-2 flex items-center justify-center w-12 h-12 ${theme === 'light' ? 'bg-primary text-light' : 'bg-light-light dark:bg-light-dark text-light-dark dark:text-gray-300'
                        }`}
                >
                    <SunIcon className="w-5 h-5" />
                </ToggleGroup.Item>
                <ToggleGroup.Item
                    value="dark"
                    className={`p-2 flex items-center justify-center w-12 h-12 ${theme === 'dark' ? 'bg-primary text-light' : 'bg-light-light dark:bg-light-dark text-light-dark dark:text-gray-300'
                        }`}
                >
                    <BsMoonStars className="w-5 h-5" />
                </ToggleGroup.Item>
            </ToggleGroup.Root>
        </div>
    );
}