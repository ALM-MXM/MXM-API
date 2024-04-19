﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MXM.Infrastructure.Validators.ExtensionValidators
{
    public static class SendEmailExtentionValidate
    {
        public static bool ValidateEmailBodyIsHtml(this string emailBody)
        {
            var validateHtmlBody = Regex.IsMatch(emailBody, @"^\s*<(!DOCTYPE\s)?html\b", RegexOptions.IgnoreCase);
            if (!validateHtmlBody) return false;
            return true;
        }
        public static bool ValidateEmailMessageIsInappropriate( this string emailMessage)
        {
            const string containsWordsInappropriate = @"\b(fuck|shit|asshole|cunt|bitch|motherfucker|bastard|dick|cock|suicide|kill myself|end my life|take my own life|suicidal|self-harm|self-destructive|crime|murder|hate|racist|violence|foder|merda|filho da puta|cadela|buraco do cu|vagabundo|idiota|otário|caralho|cona|suicídio|matar-me|tirar minha própria vida|suicida|auto-mutilação|autodestrutivo|puta|vadia|vou te matar|se mata|vai se foder|vsf)\b";
            Regex regex = new Regex(containsWordsInappropriate, RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(emailMessage);
            if (matches.Count > 0) return false;
            return true;
        }
    }
}