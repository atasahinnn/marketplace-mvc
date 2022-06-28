! function(e, t) {
    "function" == typeof define && define.amd ? define([], t("Navigation")) : "object" == typeof exports ? module.exports = t("Navigation") : e.Navigation = t("Navigation")
}(this, function(e) {
    "use strict";
    var t = {
            breakpoint: 992,
            submenuTrigger: "hover",
            overlay: !0,
            overlayColor: "rgba(0, 0, 0, 0.7)",
            autoSubmenuIndicator: !0,
            submenuIndicatorTrigger: !1,
            hideSubWhenClickOut: !0,
            scrollMomentum: !0,
            scrollSpy: !1,
            scrollSpySpeed: 1e3,
            scrollSpyOffset: 0,
            landscapeClass: "navigation-landscape",
            onInit: function() {},
            onLandscape: function() {},
            onShowOffCanvas: function() {},
            onHideOffCanvas: function() {}
        },
        n = function(e, n) {
            var i, a = {};
            for (i in t) Object.prototype.hasOwnProperty.call(t, i) && (a[i] = t[i]);
            for (i in n) Object.prototype.hasOwnProperty.call(n, i) && (a[i] = n[i]);
            return a
        },
        i = function(e, t, n) {
            this.namespaces || (this.namespaces = {}), this.namespaces[e] = t;
            var i = n || !1;
            return this.addEventListener(e.split(".")[0], t, i), this
        },
        a = function(e, t) {
            if (void 0 !== this.namespaces && this.namespaces[e]) return this.removeEventListener(e.split(".")[0], this.namespaces[e], t), delete this.namespaces[e], this
        },
        o = function(e) {
            if (void 0 !== this.namespaces) return !!this.namespaces[e]
        };
    window.on = document.on = Element.prototype.on = i, window.off = document.off = Element.prototype.off = a, window.check = document.check = Element.prototype.check = o;
    var s = function(e, t) {
            for (; null !== e && "html" !== e.tagName.toLowerCase();) {
                if (e.classList.length > 0 && e.classList.contains(t)) return !0;
                e = e.parentNode
            }
            return !1
        },
        r = function() {
            return window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth
        };
    return function(e, i) {
        var a, o, l = Number.MAX_VALUE,
            c = 1;
        if (null === e) return !1;
        (a = e).init = function(e) {
            a.options = n(t, e), a.navigationBody = a.getElementsByClassName("navigation-body")[0], a.menuItems = a.querySelectorAll(".navigation-item, .navigation-dropdown-item"), a.menuLinks = a.querySelectorAll(".navigation-link, .navigation-dropdown-link");
            for (var i = a.querySelectorAll(".navigation-dropdown, .navigation-megamenu"), r = 0; r < i.length; r++) i[r].className += " navigation-submenu", i[r].parentNode.className += " has-submenu";
            if (a.options.autoSubmenuIndicator)
                for (r = 0; r < a.menuItems.length; r++)
                    if (a.menuItems[r].classList.contains("has-submenu")) {
                        var l = document.createElement("span");
                        l.classList.add("submenu-indicator"), a.menuItems[r].children[1].classList.contains("navigation-dropdown-left") && l.classList.add("submenu-indicator-left"), a.menuItems[r].children[0].appendChild(l)
                    } o = !matchMedia("(hover: none)").matches, u(), window.on("resize", u), a.options.overlay && (a.overlayPanel = document.createElement("div"), a.overlayPanel.classList.add("overlay-panel"), a.overlayPanel.style.background = a.options.overlayColor, a.appendChild(a.overlayPanel), a.overlayPanel.addEventListener("click", a.toggleOffcanvas)), a.getElementsByClassName("navigation-button-toggler")[0].on("click", function(e) {
                e.stopPropagation(), e.preventDefault(), a.toggleOffcanvas()
            }), a.getElementsByClassName("navigation-body-close-button")[0].on("click", a.toggleOffcanvas), a.options.hideSubWhenClickOut && (document.on("touchstart.body", function(e) {
                !1 === s(e.target, "navigation") && a.hideSubmenus("BODY")
            }), document.on("click.body", function(e) {
                !1 === s(e.target, "navigation") && a.hideSubmenus("BODY")
            }));
            var c = a.querySelectorAll(".navigation-tabs");
            if (c.length > 0)
                for (r = 0; r < c.length; r++) b(c[r]);
            a.options.scrollMomentum && a.navigationBody.classList.add("scroll-momentum"), a.options.onInit.call()
        };
        var u = function() {
            h(), r() < a.options.breakpoint && l > a.options.breakpoint && (a.classList.remove(a.options.landscapeClass), a.hideSubmenus("BODY"), v(), a.options.submenuIndicatorTrigger ? d() : (f("click.link"), d())), r() > a.options.breakpoint && c < a.options.breakpoint && (a.classList.contains(a.options.landscapeClass) || (a.className += " " + a.options.landscapeClass), a.hideSubmenus("BODY"), v(), "click" === a.options.submenuTrigger || navigator.userAgent.match(/Mobi/i) || navigator.maxTouchPoints > 1 && o ? f("click.link") : g(), a.options.onLandscape.call()), l = r(), c = r()
        };

        function m(e, t) {
            setTimeout(function() {
                e.classList.remove("is-visible")
            }, 100 * t)
        }
        a.toggleOffcanvas = function() {
            a.classList.contains(a.options.landscapeClass) || (a.navigationBody.classList.contains("is-visible") || a.classList.contains(a.options.landscapeClass) ? (a.navigationBody.className += " is-invisible", a.navigationBody.check("transitionend") || a.navigationBody.on("transitionend", function() {
                a.navigationBody.classList.remove("is-visible"), a.navigationBody.classList.remove("is-invisible"), a.navigationBody.off("transitionend")
            }), a.overlayPanel.className += " is-invisible", a.overlayPanel.check("transitionend") || a.overlayPanel.on("transitionend", function() {
                a.overlayPanel.classList.remove("is-visible"), a.overlayPanel.classList.remove("is-invisible"), a.overlayPanel.off("transitionend")
            }), a.options.onHideOffCanvas.call()) : (a.navigationBody.className += " is-visible", a.overlayPanel.classList.add("is-visible"), a.options.onShowOffCanvas.call()))
        }, a.showSubmenu = function(e) {
            e.nextElementSibling.classList.contains("is-visible") || (e.nextElementSibling.className += " is-visible"), p(e)
        }, a.hideSubmenus = function(e) {
            for (var t, n = (t = "BODY" === e ? a.querySelectorAll(".navigation-submenu.is-visible") : e.parentNode.querySelectorAll(".navigation-submenu.is-visible")).length - 1; n >= 0; n--) a.classList.contains(a.options.landscapeClass) ? m(t[n], t.length - n) : t[n].classList.remove("is-visible"), t[n].parentNode.classList.remove("is-active"), t[n].previousElementSibling.getElementsByClassName("submenu-indicator").length > 0 && t[n].previousElementSibling.lastElementChild.classList.remove("is-active")
        };
        var f = function(e) {
                for (var t = 0; t < a.menuLinks.length; t++) a.menuLinks[t].on(e, function(e) {
                    if (e.target.parentNode.classList.contains("has-submenu")) {
                        if (e.preventDefault(), e.stopPropagation(), !e.target.parentNode.classList.contains("is-active")) return e.target.parentNode.classList.contains("navigation-item") && a.hideSubmenus("BODY"), e.target.parentNode.className += " is-active", e.target.getElementsByClassName("submenu-indicator").length > 0 && (e.target.lastElementChild.className += " is-active"), a.hideSubmenus(e.target.parentNode), a.showSubmenu(e.target), !1;
                        if (e.target.parentNode.classList.remove("is-active"), e.target.getElementsByClassName("submenu-indicator").length > 0 && e.target.lastElementChild.classList.remove("is-active"), a.hideSubmenus(e.target), "_blank" === e.target.getAttribute("target") || "blank" === e.target.getAttribute("target")) window.open(e.target.getAttribute("href"));
                        else {
                            if ("#" === e.target.getAttribute("href") || "" === e.target.getAttribute("href") || "javascript:void(0)" === e.target.getAttribute("href")) return !1;
                            window.location.href = e.target.getAttribute("href")
                        }
                    }
                })
            },
            d = function() {
                a.navigationBody.on("click.indicator", function(e) {
                    e.target.classList.length > 0 && e.target.classList.contains("submenu-indicator") && (e.preventDefault(), e.stopPropagation(), e.target.classList.contains("is-active") ? (e.target.classList.remove("is-active"), e.target.parentNode.parentNode.classList.remove("is-active"), a.hideSubmenus(e.target.parentNode)) : (e.target.parentNode.parentNode.classList.contains("navigation-item") && a.hideSubmenus("BODY"), e.target.className += " is-active", e.target.parentNode.parentNode.classList.add("is-active"), a.showSubmenu(e.target.parentNode)))
                })
            },
            g = function() {
                for (var e = 0; e < a.menuItems.length; e++) a.menuItems[e].classList.contains("has-submenu") && (a.menuItems[e].on("mouseenter.item", function(e) {
                    e.preventDefault(), e.stopPropagation(), e.target.classList.contains("has-submenu") && (a.showSubmenu(e.target.firstElementChild), e.target.className += " is-active")
                }), a.menuItems[e].on("mouseleave.item", function(e) {
                    if (e.preventDefault(), e.stopPropagation(), e.target.classList.contains("has-submenu")) {
                        var t = (n = e.target.lastElementChild, {
                            x: (i = n.getBoundingClientRect()).left,
                            y: i.top
                        });
                        (e.clientX < t.x || e.clientX > t.x + e.target.lastElementChild.offsetWidth || e.clientY < t.y || e.clientY > t.y + e.target.lastElementChild.offsetHeight) && (a.hideSubmenus(e.target.firstElementChild), e.target.classList.remove("is-active"))
                    }
                    var n, i
                }))
            },
            v = function() {
                a.navigationBody.off("click.indicator");
                for (var e = 0; e < a.menuItems.length; e++) a.menuItems[e].off("mouseenter.item"), a.menuItems[e].off("mouseleave.item");
                for (e = 0; e < a.menuLinks.length; e++) a.menuLinks[e].off("click.link")
            },
            p = function(e) {
                if (r() > a.options.breakpoint) {
                    var t = a.navigationBody.offsetWidth;
                    e.classList.contains("navigation-link") && (e.offsetLeft + e.nextElementSibling.offsetWidth > t ? e.nextElementSibling.style.right = 0 : e.nextElementSibling.style.right = "auto")
                }
            },
            h = function() {
                for (var e = a.navigationBody.querySelectorAll(".navigation-item > .navigation-submenu"), t = a.navigationBody.offsetWidth, n = 0; n < e.length; n++) e[n].previousElementSibling.offsetLeft + e[n].offsetWidth > t ? e[n].style.right = 0 : e[n].style.right = "auto"
            },
            b = function(e) {
                for (var t = e.getElementsByClassName("navigation-tabs-nav-item"), n = e.getElementsByClassName("navigation-tabs-pane"), i = 0; i < t.length; i++) t[i].on("mouseover.tabs", function(e) {
                    e.preventDefault(), e.stopImmediatePropagation();
                    for (var i = 0; i < t.length; i++) t[i].classList.remove("is-active");
                    for (e.target.parentNode.classList.add("is-active"), i = 0; i < n.length; i++) n[i].classList.remove("is-active");
                    n[a(e.target.parentNode)].classList.add("is-active")
                });

                function a(e) {
                    for (var t = e.parentNode.childNodes, n = 0, i = 0; i < t.length; i++) {
                        if (t[i] == e) return n;
                        1 == t[i].nodeType && n++
                    }
                    return -1
                }
            },
            y = function() {
                var e = a.querySelectorAll(".navigation-link[href*='#']"),
                    t = function(e) {
                        for (var t = [], n = 0; n < e.length; n++) {
                            var i = e[n].getAttribute("href");
                            if (i.length > 1 && "#" === i.substring(0, 1)) {
                                var a = document.getElementById(i.substr(1)),
                                    o = Math.floor(a.offsetTop),
                                    s = o + Math.floor(a.offsetHeight);
                                t.push({
                                    element: i,
                                    hash: i,
                                    top: o,
                                    bottom: s
                                })
                            }
                        }
                        return t
                    },
                    n = function(e, t) {
                        for (var n = 0; n < e.length; n++) {
                            var i = e[n];
                            if (i.getAttribute("href") === t) return i
                        }
                    },
                    i = function(e) {
                        for (var t = 0; t < e.length; t++) e[t].parentNode.classList.remove("is-active")
                    },
                    o = function(e, t, n, i) {
                        var o = {
                                linear: function(e) {
                                    return e
                                },
                                easeInQuad: function(e) {
                                    return e * e
                                },
                                easeOutQuad: function(e) {
                                    return e * (2 - e)
                                },
                                easeInOutQuad: function(e) {
                                    return e < .5 ? 2 * e * e : (4 - 2 * e) * e - 1
                                },
                                easeInCubic: function(e) {
                                    return e * e * e
                                },
                                easeOutCubic: function(e) {
                                    return --e * e * e + 1
                                },
                                easeInOutCubic: function(e) {
                                    return e < .5 ? 4 * e * e * e : (e - 1) * (2 * e - 2) * (2 * e - 2) + 1
                                },
                                easeInQuart: function(e) {
                                    return e * e * e * e
                                },
                                easeOutQuart: function(e) {
                                    return 1 - --e * e * e * e
                                },
                                easeInOutQuart: function(e) {
                                    return e < .5 ? 8 * e * e * e * e : 1 - 8 * --e * e * e * e
                                },
                                easeInQuint: function(e) {
                                    return e * e * e * e * e
                                },
                                easeOutQuint: function(e) {
                                    return 1 + --e * e * e * e * e
                                },
                                easeInOutQuint: function(e) {
                                    return e < .5 ? 16 * e * e * e * e * e : 1 + 16 * --e * e * e * e * e
                                }
                            },
                            s = window.pageYOffset,
                            r = "now" in window.performance ? performance.now() : (new Date).getTime(),
                            l = Math.max(document.body.scrollHeight, document.body.offsetHeight, document.documentElement.clientHeight, document.documentElement.scrollHeight, document.documentElement.offsetHeight),
                            c = window.innerHeight || document.documentElement.clientHeight || document.getElementsByTagName("body")[0].clientHeight,
                            u = "number" == typeof e ? e : e.offsetTop + a.options.scrollSpyOffset,
                            m = Math.round(l - u < c ? l - c : u);
                        if ("requestAnimationFrame" in window == 0) return window.scroll(0, m), void(i && i());
                        ! function e() {
                            var a = "now" in window.performance ? performance.now() : (new Date).getTime(),
                                l = Math.min(1, (a - r) / t),
                                c = o[n](l);
                            m < 0 && (m = 0), window.scroll(0, Math.ceil(c * (m - s) + s)), window.pageYOffset !== m ? requestAnimationFrame(e) : i && i()
                        }()
                    };
                ! function() {
                    for (var s = 0; s < e.length; s++) e[s].on("click.scrollSpy", function(e) {
                        if (!e.target.classList.contains("submenu-indicator") && e.target.getAttribute("href").length > 1 && "#" === e.target.getAttribute("href").substring(0, 1)) {
                            var t = e.target.getAttribute("href");
                            document.getElementById(t.replace("#", "")), t.length > 0 && o(document.querySelector(t), a.options.scrollSpySpeed, "easeInOutCubic")
                        }
                    });
                    var r = t(e);
                    window.on("resize.scrollSpy", function() {
                        r = [], r = t(e)
                    }), window.on("scroll.scrollSpy", function() {
                        for (var t, o, s, l = (t = this.pageYOffset, o = Math.abs(a.options.scrollSpyOffset), parseInt(t, 10) + parseInt(o, 10)), c = (this.pageXOffset, 0); c < r.length; c++) {
                            var u = r[c];
                            if (l >= u.top && l < u.bottom) {
                                var m = u.hash;
                                if (s = n(e, m)) {
                                    i(e), s.parentNode.classList.add("is-active");
                                    break
                                }
                            }
                        }
                    })
                }()
            };
        return a.init(i), a.options.scrollSpy && (window.onload = function() {
            y()
        }), a
    }
});